using Microsoft.EntityFrameworkCore;
using Transactly.Data.Data.Contexts;
using Transactly.Data.Models;

namespace Transactly.Data.Data.Repositories
{
    public class CurrencyRepository(TransactlyDbContext dbContext) : BaseRepository(dbContext)
    {
        private readonly TransactlyDbContext _dbContext = dbContext;
        public async Task<IEnumerable<ExchangeRate>> GetAllExchangeRatesByCurrencyId(int id)
        {
            return await _dbContext.ExchangeRates.Where(e => e.CurrencyId == id).ToListAsync();
        }

        public async Task<ExchangeRate?> GetExchangeRateByCurrencyIds(int baseId, int targetId)
        {
            return await _dbContext.ExchangeRates.Where(e => e.CurrencyId == baseId && e.ExchangeCurrencyId == targetId).FirstOrDefaultAsync();
        }

        public async Task<decimal> Exchange(decimal amount, int baseId, int targetId)
        {
            var exchangeRate = await GetExchangeRateByCurrencyIds(baseId, targetId);
            return exchangeRate == null ? throw new Exception("Exchange rate not found") : amount * exchangeRate.Rate;
        }
    }
}
