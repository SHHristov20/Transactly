using Transactly.Data.Data.Contexts;
using Transactly.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Transactly.Data.Data.Repositories
{
    public class UserRepository(TransactlyDbContext dbContext) : BaseRepository(dbContext)
    {
        private readonly TransactlyDbContext _dbContext = dbContext;

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserByUserTag(string userTag)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserTag == userTag);
        }

        public async Task<User?> GetUserByPhoneNumber(string phoneNumber)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }
    }
}
