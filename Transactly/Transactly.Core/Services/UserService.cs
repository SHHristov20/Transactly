using Transactly.Core.Interfaces;
using Transactly.Data.Data.Repositories;
using Transactly.Data.Interfaces;
using Transactly.Data.Models;

namespace Transactly.Core.Services
{
    public class UserService(IBaseRepository repository, UserRepository userRepository) : BaseService(repository), IUserService
    {
        private readonly UserRepository _userRepository = userRepository;

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<User?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _userRepository.GetUserByPhoneNumber(phoneNumber);
        }
        public async Task<User?> GetUserByToken(Guid token)
        {
            return await _userRepository.GetUserByToken(token);
        }       
    }
}
