using Transactly.Data.Data.Contexts;
using Transactly.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Transactly.Data.Data.Repositories
{
    public class AccountRepository(TransactlyDbContext dbContext) : BaseRepository(dbContext)
    {
        private readonly TransactlyDbContext _dbContext = dbContext;

        // add money to account

    }
}
