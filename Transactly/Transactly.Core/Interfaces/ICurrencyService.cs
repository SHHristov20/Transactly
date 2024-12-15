using Microsoft.EntityFrameworkCore;
using Transactly.Data.Models;

namespace Transactly.Core.Interfaces
{
    public interface ICurrencyService : IBaseService
    {
        Task<IEnumerable<ExchangeRate>> GetAllExchangeRatesByCurrencyId(int id);
        Task<ExchangeRate?> GetExchangeRateByCurrencyIds(int baseId, int targetId);
        Task<decimal> Exchange(decimal amount, int baseId, int targetId);
    }
}
