using Microsoft.EntityFrameworkCore;
using Transactly.Core.Interfaces;
using Transactly.Data.Data.Repositories;
using Transactly.Data.Interfaces;
using Transactly.Data.Models;

namespace Transactly.Core.Services
{
    public class CurrencyService(IBaseRepository repository, CurrencyRepository currencyRepository) : BaseService(repository), ICurrencyService
    {
        private readonly CurrencyRepository _currencyRepository = currencyRepository;
        public async Task<IEnumerable<ExchangeRate>> GetAllExchangeRatesByCurrencyId(int id)
        {
            return await _currencyRepository.GetAllExchangeRatesByCurrencyId(id);
        }

        public async Task<ExchangeRate?> GetExchangeRateByCurrencyIds(int baseId, int targetId)
        {
            return await _currencyRepository.GetExchangeRateByCurrencyIds(baseId, targetId);
        }

        public async Task<decimal> Exchange(decimal amount, int baseId, int targetId)
        {
            return await _currencyRepository.Exchange(amount, baseId, targetId);
        }
    }
}
