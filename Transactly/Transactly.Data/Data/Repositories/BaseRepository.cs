using Microsoft.EntityFrameworkCore;
using Transactly.Data.Data.Contexts;
using Transactly.Data.Interfaces;

namespace Transactly.Data.Data.Repositories
{
    public class BaseRepository(TransactlyDbContext dbContext) : IBaseRepository
    {
        private readonly TransactlyDbContext _dbContext = dbContext;

        public async  Task<bool> Create<T>(T entity) where T : class
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Update(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete<T>(T entity) where T : class
        {
            _dbContext.Set<T>().Remove(entity);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<T?> GetById<T>(int id) where T : class
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : class
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
    }
}
