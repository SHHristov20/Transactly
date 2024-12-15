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
        public DbSet<Card> Cards { get; set; } = null!;
        public DbSet<ExchangeRate> ExchangeRates { get; set; } = null!;

        public TransactlyDbContext() { }
        public TransactlyDbContext(DbContextOptions<TransactlyDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Transactly;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False")
                .UseLazyLoadingProxies();
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

            modelBuilder.Entity<Card>()
                .Property(x => x.Id)
                .UseIdentityColumn();

            modelBuilder.Entity<ExchangeRate>()
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

            modelBuilder.Entity<Card>()
                .HasOne(c => c.Account)
                .WithMany(a => a.Cards)
                .HasForeignKey(c => c.AccountId);

            modelBuilder.Entity<ExchangeRate>()
                .HasOne(er => er.Currency)
                .WithMany(c => c.ExchangeRates)
                .HasForeignKey(er => er.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeRate>()
                .HasOne(er => er.ExchangeCurrency)
                .WithMany(c => c.ExchangeCurrencyRates)
                .HasForeignKey(er => er.ExchangeCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            SeedData(modelBuilder);

        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            SeedCurrencies(modelBuilder);
            SeedTransactionTypes(modelBuilder);
            SeedExchangeRates(modelBuilder);
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

        private void SeedExchangeRates(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExchangeRate>().HasData(
                new ExchangeRate { Id = 1, CurrencyId = 1, ExchangeCurrencyId = 2, Rate = 0.54m },
                new ExchangeRate { Id = 2, CurrencyId = 1, ExchangeCurrencyId = 3, Rate = 0.51m },
                new ExchangeRate { Id = 3, CurrencyId = 1, ExchangeCurrencyId = 4, Rate = 0.42m },
                new ExchangeRate { Id = 4, CurrencyId = 1, ExchangeCurrencyId = 5, Rate = 82.66m },
                new ExchangeRate { Id = 5, CurrencyId = 1, ExchangeCurrencyId = 6, Rate = 0.84m },
                new ExchangeRate { Id = 6, CurrencyId = 2, ExchangeCurrencyId = 1, Rate = 1.86m },
                new ExchangeRate { Id = 7, CurrencyId = 2, ExchangeCurrencyId = 3, Rate = 0.95m },
                new ExchangeRate { Id = 8, CurrencyId = 2, ExchangeCurrencyId = 4, Rate = 0.79m },
                new ExchangeRate { Id = 9, CurrencyId = 2, ExchangeCurrencyId = 5, Rate = 153.86m },
                new ExchangeRate { Id = 10, CurrencyId = 2, ExchangeCurrencyId = 6, Rate = 1.57m },
                new ExchangeRate { Id = 11, CurrencyId = 3, ExchangeCurrencyId = 1, Rate = 1.96m },
                new ExchangeRate { Id = 12, CurrencyId = 3, ExchangeCurrencyId = 2, Rate = 1.05m },
                new ExchangeRate { Id = 13, CurrencyId = 3, ExchangeCurrencyId = 4, Rate = 0.83m },
                new ExchangeRate { Id = 14, CurrencyId = 3, ExchangeCurrencyId = 5, Rate = 161.67m },
                new ExchangeRate { Id = 15, CurrencyId = 3, ExchangeCurrencyId = 6, Rate = 1.65m },
                new ExchangeRate { Id = 16, CurrencyId = 4, ExchangeCurrencyId = 1, Rate = 2.36m },
                new ExchangeRate { Id = 17, CurrencyId = 4, ExchangeCurrencyId = 2, Rate = 1.26m },
                new ExchangeRate { Id = 18, CurrencyId = 4, ExchangeCurrencyId = 3, Rate = 1.20m },
                new ExchangeRate { Id = 19, CurrencyId = 4, ExchangeCurrencyId = 5, Rate = 194.30m },
                new ExchangeRate { Id = 20, CurrencyId = 4, ExchangeCurrencyId = 6, Rate = 1.98m },
                new ExchangeRate { Id = 21, CurrencyId = 5, ExchangeCurrencyId = 1, Rate = 0.012m },
                new ExchangeRate { Id = 22, CurrencyId = 5, ExchangeCurrencyId = 2, Rate = 0.0065m },
                new ExchangeRate { Id = 23, CurrencyId = 5, ExchangeCurrencyId = 3, Rate = 0.0062m },
                new ExchangeRate { Id = 24, CurrencyId = 5, ExchangeCurrencyId = 4, Rate = 0.0052m },
                new ExchangeRate { Id = 25, CurrencyId = 5, ExchangeCurrencyId = 6, Rate = 0.01m },
                new ExchangeRate { Id = 26, CurrencyId = 6, ExchangeCurrencyId = 1, Rate = 1.18m },
                new ExchangeRate { Id = 27, CurrencyId = 6, ExchangeCurrencyId = 2, Rate = 0.64m },
                new ExchangeRate { Id = 28, CurrencyId = 6, ExchangeCurrencyId = 3, Rate = 0.61m },
                new ExchangeRate { Id = 29, CurrencyId = 6, ExchangeCurrencyId = 4, Rate = 0.5m },
                new ExchangeRate { Id = 30, CurrencyId = 6, ExchangeCurrencyId = 5, Rate = 97.88m }
            );
        }
    }
}
