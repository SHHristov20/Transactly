using Transactly.Data.Models;
using Transactly.Core.Interfaces;

namespace Transactly.Core.Interfaces
{
    public interface IUserService : IBaseService
    {
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserByPhoneNumber(string phoneNumber);
    }
}
