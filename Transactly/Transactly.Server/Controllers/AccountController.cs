using Microsoft.AspNetCore.Mvc;
using Transactly.Core.Interfaces;
using Transactly.Core.DTOs;
using Transactly.Data.Models;
using Transactly.Core.Validators;

namespace Transactly.Server.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AccountController(IAccountService accountService) : ControllerBase
    {
        private readonly IAccountService _accountService = accountService;

        [HttpPost(Name = "CreateAccount")]

        public async Task<IActionResult> Create([FromBody] CreateAccountDTO model)
        {
            Random random = new();
            string accountNumber = "";
            for (int i = 0; i < 16; i++)
            {
                accountNumber += random.Next(0, 9).ToString();
            }
            Account account = new Account
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
            Account ?account = await _accountService.GetById<Account>(model.AccountId);
            if (account == null)
            {
                return BadRequest(new { message = "Account not found!", errorCode = 404 });
            }
            if (model.Amount <= 0)
            {
                return BadRequest(new { message = "Amount must be greater than 0!", errorCode = 400 });
            }
            if(CardValidator.IsValidCreditCardNumber(model.CardNumber) == false)
            {
                return BadRequest(new { message = "Invalid card number!", errorCode = 400 });
            }
            if(CardValidator.IsValidExpiryDate(model.ExpiryDate) == false)
            {
                return BadRequest(new { message = "Invalid expiration date!", errorCode = 400 });
            }
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
            bool result2 = await _accountService.Create<Transaction>(transaction);
            if (result && result2)
            {
                return Ok();
            }
            return BadRequest(new { message = "Failed to deposit funds!", errorCode = 500 });
        }
    }
}
