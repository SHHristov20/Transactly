using Microsoft.AspNetCore.Mvc;
using Transactly.Core.Interfaces;
using Transactly.Core.DTOs;
using Transactly.Data.Models;

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
    }
}
