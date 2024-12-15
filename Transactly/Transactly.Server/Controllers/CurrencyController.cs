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
    public class CurrencyController(ICurrencyService currencyService) : ControllerBase
    {
        private readonly ICurrencyService _currencyService = currencyService;

        [HttpGet(Name = "GetAllCurrencies")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _currencyService.GetAll<Currency>());
        }
    }
}