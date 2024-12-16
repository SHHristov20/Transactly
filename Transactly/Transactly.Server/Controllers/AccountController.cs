using Microsoft.AspNetCore.Mvc;
using Transactly.Core.Interfaces;
using Transactly.Core.DTOs;
using Transactly.Data.Models;
using Transactly.Core.Validators;
using Transactly.Core.Services;

namespace Transactly.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController(IAccountService accountService, ICardService cardService, IUserService userService, ICurrencyService currencyService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;
        private readonly ICardService _cardService = cardService;
        private readonly IUserService _userService = userService;
        private readonly ICurrencyService _currencyService = currencyService;

        [HttpPost(Name = "CreateAccount")]

        public async Task<IActionResult> Create([FromBody] CreateAccountDTO model)
        {
            IEnumerable<Account> accounts = await _accountService.GetAccountsByUserId(model.UserId);
            foreach (Account acc in accounts)
            {
                if (acc.CurrencyId == model.CurrencyId)
                {
                    return BadRequest(new { message = $"Account in {acc.Currency.CurrencyName} already exists!", errorCode = 400 });
                }
            }
            Random random = new();
            string accountNumber = "";
            for (int i = 0; i < 16; i++)
            {
                accountNumber += random.Next(0, 9).ToString();
            }
            Account account = new()
            {
                UserId = model.UserId,
                CurrencyId = model.CurrencyId,
                AccountNumber = accountNumber
            };
            bool result = await _accountService.Create<Account>(account);
            if (result)
            {
                return Ok();
            }
            return BadRequest(new { message = "Failed to create account!", errorCode = 500 });
        }

        [HttpPost(Name = "DepositFunds")]
        public async Task<IActionResult> Deposit([FromBody] DepositFundsDTO model)
        {
            Account? account = await _accountService.GetById<Account>(model.AccountId);
            if (account == null)
            {
                return BadRequest(new { message = "Account not found!", errorCode = 404 });
            }
            if (model.Amount <= 0)
            {
                return BadRequest(new { message = "Amount must be greater than 0!", errorCode = 400 });
            }
            if (CardValidator.IsValidCreditCardNumber(model.CardNumber) == false)
            {
                return BadRequest(new { message = "Invalid card number!", errorCode = 400 });
            }
            if (CardValidator.IsValidExpiryDate(model.ExpiryDate) == false)
            {
                return BadRequest(new { message = "Invalid expiration date!", errorCode = 400 });
            }
            if (model.CVV.Length != 3)
            {
                return BadRequest(new { message = "Invalid CVV!", errorCode = 400 });
            }
            Card? card = await _cardService.GetCardByNumber(model.CardNumber);
            if (card != null)
            {
                if (model.CVV != card.CVV || model.ExpiryDate != card.ExpiryDate)
                {
                    Transaction transaction1 = new()
                    {
                        Amount = Math.Round(model.Amount, 2),
                        Date = DateTime.Now,
                        FromAccountId = card.AccountId,
                        ToAccountId = account.Id,
                        Reason = "Deposit",
                        Status = false,
                        TypeId = 1
                    };
                    await _accountService.Create<Transaction>(transaction1);
                    return BadRequest(new { message = "Invalid card details!", errorCode = 400 });
                }
                bool result;
                if (card.Account.CurrencyId != account.CurrencyId)
                {
                    decimal convertedAmount = await _currencyService.Exchange(model.Amount, card.Account.CurrencyId, account.CurrencyId);
                    result = await _cardService.Payment(card, account, model.Amount, convertedAmount);
                }
                else
                {
                    result = await _cardService.Payment(card, account, model.Amount);
                }
                if (result == false)
                {
                    return BadRequest(new { message = "Failed to deposit funds!", errorCode = 500 });
                }
                return Ok();
            }
            else
            {
                account.Balance += Math.Round(model.Amount, 2);
                bool result = await _accountService.Update<Account>(account);
                Transaction transaction = new()
                {
                    Amount = Math.Round(model.Amount, 2),
                    Date = DateTime.Now,
                    FromAccountId = account.Id,
                    ToAccountId = account.Id,
                    Reason = "Deposit",
                    Status = true,
                    TypeId = 1
                };
                await _accountService.Create<Transaction>(transaction);
                if (result)
                {
                    return Ok();
                }
                return BadRequest(new { message = "Failed to deposit funds!", errorCode = 500 });
            }
        }

        [HttpGet(Name = "GetAllAccounts")]
        public async Task<IActionResult> GetAll([FromQuery] Guid token)
        {
            User? user = await _userService.GetUserByToken(token);
            if (user == null || user.TokenExpiry < DateTime.Now)
            {
                return BadRequest(new { message = "Invalid session token!", errorCode = 400 });
            }
            IEnumerable<Account> accounts = await _accountService.GetAccountsByUserId(user.Id);
            return Ok(accounts);
        }

        [HttpGet(Name = "GetAllTransactions")]
        public async Task<IActionResult> GetAllTransactions([FromQuery] Guid token)
        {
            User? user = await _userService.GetUserByToken(token);
            if (user == null || user.TokenExpiry < DateTime.Now)
            {
                return BadRequest(new { message = "Invalid session token!", errorCode = 400 });
            }
            IEnumerable<Account> accounts = await _accountService.GetAccountsByUserId(user.Id);
            List<Transaction> transactions = new();
            foreach (Account acc in accounts)
            {
                IEnumerable<Transaction> accTransactions = await _accountService.GetAll<Transaction>();
                foreach (Transaction trans in accTransactions)
                {
                    if (trans.FromAccountId == acc.Id || trans.ToAccountId == acc.Id)
                    {
                        transactions.Add(trans);
                    }
                }
            }
            return Ok(transactions);
        }

        [HttpGet(Name = "GetAllIncomingTransactions")]
        public async Task<IActionResult> GetAllIncomingTransactions([FromQuery] Guid token)
        {
            User? user = await _userService.GetUserByToken(token);
            if (user == null || user.TokenExpiry < DateTime.Now)
            {
                return BadRequest(new { message = "Invalid session token!", errorCode = 400 });
            }
            IEnumerable<Account> accounts = await _accountService.GetAccountsByUserId(user.Id);
            List<Transaction> transactions = new();
            foreach (Account acc in accounts)
            {
                IEnumerable<Transaction> accTransactions = await _accountService.GetAll<Transaction>();
                foreach (Transaction transaction in accTransactions)
                {
                    if (transaction.ToAccountId == acc.Id)
                    {
                        transactions.Add(transaction);
                    }
                }
            }
            return Ok(transactions);
        }

        [HttpGet(Name = "GetAllOutgoingTransactions")]
        public async Task<IActionResult> GetAllOutgoingTransactions([FromQuery] Guid token)
        {
            User? user = await _userService.GetUserByToken(token);
            if (user == null || user.TokenExpiry < DateTime.Now)
            {
                return BadRequest(new { message = "Invalid session token!", errorCode = 400 });
            }
            IEnumerable<Account> accounts = await _accountService.GetAccountsByUserId(user.Id);
            List<Transaction> transactions = new();
            foreach (Account acc in accounts)
            {
                IEnumerable<Transaction> accTransactions = await _accountService.GetAll<Transaction>();
                foreach (Transaction transaction in accTransactions)
                {
                    if (transaction.FromAccountId == acc.Id)
                    {
                        transactions.Add(transaction);
                    }
                }
            }
            return Ok(transactions);
        }

        [HttpPost(Name = "CreateCard")]
        public async Task<IActionResult> CreateCard([FromBody] CreateCardDTO model)
        {
            User? user = await _userService.GetUserByToken(model.Token);
            if (user == null || user.TokenExpiry < DateTime.Now)
            {
                return BadRequest(new { message = "Invalid session token!", errorCode = 400 });
            }
            Account? account = await _accountService.GetById<Account>(model.AccountId);
            if (account == null)
            {
                return BadRequest(new { message = "Account not found!", errorCode = 404 });
            }
            if (account.UserId != user.Id)
            {
                return BadRequest(new { message = "Account does not belong to user!", errorCode = 400 });
            }
            if (account.Cards.Count > 0)
            {
                return BadRequest(new { message = "Account already has a card!", errorCode = 400 });
            }
            string expiryDate = DateTime.Now.AddYears(5).ToString("MM/yy");
            Card card = new()
            {
                AccountId = account.Id,
                CardNumber = CardValidator.GenerateValidCardNumber(),
                ExpiryDate = expiryDate,
                CVV = CardValidator.GenerateRandomDigits(3)
            };
            bool result = await _cardService.Create<Card>(card);
            return result ? Ok() : BadRequest(new { message = "Failed to create card!", errorCode = 500 });
        }

        [HttpPost(Name = "TransferFunds")]
        public async Task<IActionResult> Transfer([FromBody] TransferFundsDTO model)
        {
            User? sender = await _userService.GetUserByToken(model.Token);
            if (sender == null || sender.TokenExpiry < DateTime.Now)
            {
                return BadRequest(new { message = "Invalid session token!", errorCode = 400 });
            }
            if (model.ToUserTag == null && model.ToAccountNumber == null && model.ToPhoneNumber == null && model.ToEmail == null)
            {
                return BadRequest(new { message = "Recipient details are missing!", errorCode = 400 });
            }
            Account? senderAccount = await _accountService.GetById<Account>(model.FromAccountId);
            if (senderAccount == null)
            {
                return BadRequest(new { message = "Account not found!", errorCode = 404 });
            }
            if (senderAccount.UserId != sender.Id)
            {
                return BadRequest(new { message = "Account does not belong to user!", errorCode = 400 });
            }
            User? recipient = null;
            Account? recipientAccount = null;
            if (model.ToUserTag != null)
            {
                recipient = await _userService.GetUserByUserTag(model.ToUserTag);
            }
            else if (model.ToAccountNumber != null)
            {
                recipientAccount = await _accountService.GetAccountByNumber(model.ToAccountNumber);
                if (recipientAccount == null)
                {
                    return BadRequest(new { message = "Recipient account not found!", errorCode = 404 });
                }
                recipient = await _userService.GetById<User>(recipientAccount.UserId);
            }
            else if (model.ToPhoneNumber != null)
            {
                recipient = await _userService.GetUserByPhoneNumber(model.ToPhoneNumber);
            }
            else
            {
                recipient = await _userService.GetUserByEmail(model.ToEmail);
            }
            if (recipient == null)
            {
                return BadRequest(new { message = "Recipient not found!", errorCode = 404 });
            }
            if (recipient.Id == sender.Id)
            {
                return BadRequest(new { message = "Cannot transfer funds to yourself!", errorCode = 400 });
            }
            else
            {
                IEnumerable<Account> recipientAccounts = await _accountService.GetAccountsByUserId(recipient.Id);
                if (recipientAccounts.Count() == 0)
                {
                    return BadRequest(new { message = "Recipient has no accounts!", errorCode = 400 });
                }
                foreach (Account account in recipientAccounts)
                {
                    if (account.CurrencyId == senderAccount.CurrencyId)
                    {
                        recipientAccount = account;
                        break;
                    }
                }
                if (recipientAccount == null)
                {
                    recipientAccount = recipientAccounts.First();
                }
            }
            if (model.Amount <= 0)
            {
                return BadRequest(new { message = "Amount must be greater than 0!", errorCode = 400 });
            }
            if (senderAccount.Balance < model.Amount)
            {
                Transaction t = new()
                {
                    Amount = model.Amount,
                    Date = DateTime.Now,
                    FromAccountId = senderAccount.Id,
                    ToAccountId = recipientAccount.Id,
                    Reason = model.Reason,
                    Status = false,
                    TypeId = 2
                };
                await _accountService.Create<Transaction>(t);
                return BadRequest(new { message = "Insufficient funds!", errorCode = 400 });
            }
            senderAccount.Balance -= model.Amount;
            if (senderAccount.CurrencyId != recipientAccount.CurrencyId)
            {
                decimal convertedAmount = await _currencyService.Exchange(model.Amount, senderAccount.CurrencyId, recipientAccount.CurrencyId);
                recipientAccount.Balance += convertedAmount;
            }
            else
            {
                recipientAccount.Balance += model.Amount;
            }
            await _accountService.Update<Account>(senderAccount);
            await _accountService.Update<Account>(recipientAccount);
            Transaction transaction = new()
            {
                Amount = model.Amount,
                Date = DateTime.Now,
                FromAccountId = senderAccount.Id,
                ToAccountId = recipientAccount.Id,
                Reason = model.Reason,
                Status = true,
                TypeId = 2
            };
            await _accountService.Create<Transaction>(transaction);
            return Ok();
            //return await _accountService.TransferFunds(model);
        }
    }

}
