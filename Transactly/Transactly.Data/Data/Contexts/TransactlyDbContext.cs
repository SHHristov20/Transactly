using Microsoft.EntityFrameworkCore;

namespace Transactly.Data.Data.Contexts
{
    public class TransactlyDbContext : DbContext
    {


        public TransactlyDbContext() { }
        public TransactlyDbContext(DbContextOptions<TransactlyDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Transactly;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
