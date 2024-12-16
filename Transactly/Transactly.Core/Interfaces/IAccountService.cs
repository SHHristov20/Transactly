using Transactly.Data.Models;

namespace Transactly.Core.Interfaces
{
    public interface IAccountService : IBaseService
    {
        Task<IEnumerable<Account>> GetAccountsByUserId(int id);
        Task<Account?> GetAccountByNumber(string accountNumber);
    }
}
