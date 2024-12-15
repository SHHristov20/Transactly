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

    }
}
