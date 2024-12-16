using Microsoft.AspNetCore.Mvc;
using Transactly.Core.Interfaces;
using Transactly.Core.DTOs;
using Transactly.Data.Models;
using Transactly.Core.Validators;
using Transactly.Core.Services;
using Microsoft.IdentityModel.Tokens;

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

        [HttpGet(Name = "GetExchangeRateByIds")]
        public async Task<IActionResult> GetExchangeRateByIds([FromQuery] int fromCurrencyId, int toCurrencyId)
        {
            if (fromCurrencyId == toCurrencyId)
            {
                return BadRequest(new { message = "Base and target currency cannot be the same!", errorCode = 400 });
            }
            ExchangeRate ?exchangeRate = await _currencyService.GetExchangeRateByCurrencyIds(fromCurrencyId, toCurrencyId);
            if (exchangeRate == null)
            {
                return BadRequest(new { message = "Exchange rate not found!", errorCode = 404 });
            }
            return Ok(exchangeRate);
        }

        [HttpGet(Name = "GetExchangeRatesById")]
        public async Task<IActionResult> GetExchangeRateByCurrencyId([FromQuery] int currencyId)
        {
            IEnumerable<ExchangeRate> exchangeRates = await _currencyService.GetAllExchangeRatesByCurrencyId(currencyId);
            if (exchangeRates.IsNullOrEmpty())
            {
                return BadRequest(new { message = "Exchange rate not found!", errorCode = 404 });
            }
            return Ok(exchangeRates);
        }
    }
}