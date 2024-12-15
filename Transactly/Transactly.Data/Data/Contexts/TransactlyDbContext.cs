using Microsoft.EntityFrameworkCore;
using Transactly.Data.Models;

namespace Transactly.Data.Data.Contexts
{
    public class TransactlyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Currency> Currencies { get; set; } = null!;
        public DbSet<Transaction> Transactions { get; set; } = null!;
        public DbSet<TransactionType> TransactionTypes { get; set; } = null!;

        public TransactlyDbContext() { }
        public TransactlyDbContext(DbContextOptions<TransactlyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Transactly;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Account>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Currency>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<Transaction>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<TransactionType>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<User>()
                .HasMany(u => u.Accounts)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Currency)
                .WithMany(c => c.Accounts)
                .HasForeignKey(a => a.CurrencyId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.Type)
                .WithMany(tt => tt.Transactions)
                .HasForeignKey(t => t.TypeId);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.FromAccount)
                .WithMany(a => a.IncomingTransactions)
                .HasForeignKey(t => t.FromAccountId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Transaction>()
                .HasOne(t => t.ToAccount)
                .WithMany(a => a.OutgoingTransactions)
                .HasForeignKey(t => t.ToAccountId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
