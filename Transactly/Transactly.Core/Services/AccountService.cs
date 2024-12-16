using Transactly.Core.Interfaces;
using Transactly.Data.Data.Repositories;
using Transactly.Data.Interfaces;
using Transactly.Data.Models;

namespace Transactly.Core.Services
{
    public class AccountService(IBaseRepository repository, AccountRepository accountRepository) : BaseService(repository), IAccountService
    {
        private readonly AccountRepository _accountRepository = accountRepository;
        public async Task<IEnumerable<Account>> GetAccountsByUserId(int id)
        {
            return await _accountRepository.GetAccountsByUserId(id);
        }

        public async Task<Account?> GetAccountByNumber(string accountNumber)
        {
            return await _accountRepository.GetAccountByNumber(accountNumber);
        }
    }
}
