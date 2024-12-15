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

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedCurrencies(modelBuilder);
            SeedTransactionTypes(modelBuilder);
        }

        private void SeedTransactionTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType { Id = 1, Type = "Deposit" },
                new TransactionType { Id = 2, Type = "Withdrawal" },
                new TransactionType { Id = 3, Type = "Transfer" },
                new TransactionType { Id = 4, Type = "Exchange" },
                new TransactionType { Id = 5, Type = "Card Payment" }
            );
        }

        private void SeedCurrencies(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Currency>().HasData(
                new Currency { Id = 1, CurrencyName = "Bulgarian Lev", CurrencyCode = "BGN", CurrencySymbol = "лв" },
                new Currency { Id = 2, CurrencyName = "US Dollar", CurrencyCode = "USD", CurrencySymbol = "$" },
                new Currency { Id = 3, CurrencyName = "Euro", CurrencyCode = "EUR", CurrencySymbol = "€" },
                new Currency { Id = 4, CurrencyName = "British Pound", CurrencyCode = "GBP", CurrencySymbol = "£" },
                new Currency { Id = 5, CurrencyName = "Japanese Yen", CurrencyCode = "JPY", CurrencySymbol = "¥" },
                new Currency { Id = 6, CurrencyName = "Australian Dollar", CurrencyCode = "AUD", CurrencySymbol = "$" }
            );
        }
    }
}
