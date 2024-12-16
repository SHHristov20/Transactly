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
                .HasOne(er => er.BaseCurrency)
                .WithMany(c => c.ExchangeRates)
                .HasForeignKey(er => er.BaseCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ExchangeRate>()
                .HasOne(er => er.TargetCurrency)
                .WithMany(c => c.ExchangeCurrencyRates)
                .HasForeignKey(er => er.TargetCurrencyId)
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
                new ExchangeRate { Id = 1, BaseCurrencyId = 1, TargetCurrencyId = 2, Rate = 0.54m },
                new ExchangeRate { Id = 2, BaseCurrencyId = 1, TargetCurrencyId = 3, Rate = 0.51m },
                new ExchangeRate { Id = 3, BaseCurrencyId = 1, TargetCurrencyId = 4, Rate = 0.42m },
                new ExchangeRate { Id = 4, BaseCurrencyId = 1, TargetCurrencyId = 5, Rate = 82.66m },
                new ExchangeRate { Id = 5, BaseCurrencyId = 1, TargetCurrencyId = 6, Rate = 0.84m },
                new ExchangeRate { Id = 6, BaseCurrencyId = 2, TargetCurrencyId = 1, Rate = 1.86m },
                new ExchangeRate { Id = 7, BaseCurrencyId = 2, TargetCurrencyId = 3, Rate = 0.95m },
                new ExchangeRate { Id = 8, BaseCurrencyId = 2, TargetCurrencyId = 4, Rate = 0.79m },
                new ExchangeRate { Id = 9, BaseCurrencyId = 2, TargetCurrencyId = 5, Rate = 153.86m },
                new ExchangeRate { Id = 10, BaseCurrencyId = 2, TargetCurrencyId = 6, Rate = 1.57m },
                new ExchangeRate { Id = 11, BaseCurrencyId = 3, TargetCurrencyId = 1, Rate = 1.96m },
                new ExchangeRate { Id = 12, BaseCurrencyId = 3, TargetCurrencyId = 2, Rate = 1.05m },
                new ExchangeRate { Id = 13, BaseCurrencyId = 3, TargetCurrencyId = 4, Rate = 0.83m },
                new ExchangeRate { Id = 14, BaseCurrencyId = 3, TargetCurrencyId = 5, Rate = 161.67m },
                new ExchangeRate { Id = 15, BaseCurrencyId = 3, TargetCurrencyId = 6, Rate = 1.65m },
                new ExchangeRate { Id = 16, BaseCurrencyId = 4, TargetCurrencyId = 1, Rate = 2.36m },
                new ExchangeRate { Id = 17, BaseCurrencyId = 4, TargetCurrencyId = 2, Rate = 1.26m },
                new ExchangeRate { Id = 18, BaseCurrencyId = 4, TargetCurrencyId = 3, Rate = 1.20m },
                new ExchangeRate { Id = 19, BaseCurrencyId = 4, TargetCurrencyId = 5, Rate = 194.30m },
                new ExchangeRate { Id = 20, BaseCurrencyId = 4, TargetCurrencyId = 6, Rate = 1.98m },
                new ExchangeRate { Id = 21, BaseCurrencyId = 5, TargetCurrencyId = 1, Rate = 0.012m },
                new ExchangeRate { Id = 22, BaseCurrencyId = 5, TargetCurrencyId = 2, Rate = 0.0065m },
                new ExchangeRate { Id = 23, BaseCurrencyId = 5, TargetCurrencyId = 3, Rate = 0.0062m },
                new ExchangeRate { Id = 24, BaseCurrencyId = 5, TargetCurrencyId = 4, Rate = 0.0052m },
                new ExchangeRate { Id = 25, BaseCurrencyId = 5, TargetCurrencyId = 6, Rate = 0.01m },
                new ExchangeRate { Id = 26, BaseCurrencyId = 6, TargetCurrencyId = 1, Rate = 1.18m },
                new ExchangeRate { Id = 27, BaseCurrencyId = 6, TargetCurrencyId = 2, Rate = 0.64m },
                new ExchangeRate { Id = 28, BaseCurrencyId = 6, TargetCurrencyId = 3, Rate = 0.61m },
                new ExchangeRate { Id = 29, BaseCurrencyId = 6, TargetCurrencyId = 4, Rate = 0.5m },
                new ExchangeRate { Id = 30, BaseCurrencyId = 6, TargetCurrencyId = 5, Rate = 97.88m }
            );
        }
    }
}
