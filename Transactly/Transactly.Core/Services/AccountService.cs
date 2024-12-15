using Transactly.Core.Interfaces;
using Transactly.Data.Data.Repositories;
using Transactly.Data.Interfaces;
using Transactly.Data.Models;

namespace Transactly.Core.Services
{
    public class AccountService : BaseService, IAccountService
    {
        public AccountService(IBaseRepository repository) : base(repository)
        {
        }
    }
}
