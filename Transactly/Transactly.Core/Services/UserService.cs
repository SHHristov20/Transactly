using Transactly.Core.Interfaces;
using Transactly.Data.Data.Repositories;
using Transactly.Data.Interfaces;
using Transactly.Data.Models;

namespace Transactly.Core.Services
{
    public class UserService : BaseService, IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(IBaseRepository repository, UserRepository userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public async Task<User?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _userRepository.GetUserByPhoneNumber(phoneNumber);
        }
    }
}
