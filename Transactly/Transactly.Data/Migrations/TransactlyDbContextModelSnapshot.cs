﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Transactly.Data.Data.Contexts;

#nullable disable

namespace Transactly.Data.Migrations
{
    [DbContext(typeof(TransactlyDbContext))]
    partial class TransactlyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Transactly.Data.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Transactly.Data.Models.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("CVV")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("ExpiryDate")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("Transactly.Data.Models.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrencySymbol")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CurrencyCode = "BGN",
                            CurrencyName = "Bulgarian Lev",
                            CurrencySymbol = "лв"
                        },
                        new
                        {
                            Id = 2,
                            CurrencyCode = "USD",
                            CurrencyName = "US Dollar",
                            CurrencySymbol = "$"
                        },
                        new
                        {
                            Id = 3,
                            CurrencyCode = "EUR",
                            CurrencyName = "Euro",
                            CurrencySymbol = "€"
                        },
                        new
                        {
                            Id = 4,
                            CurrencyCode = "GBP",
                            CurrencyName = "British Pound",
                            CurrencySymbol = "£"
                        },
                        new
                        {
                            Id = 5,
                            CurrencyCode = "JPY",
                            CurrencyName = "Japanese Yen",
                            CurrencySymbol = "¥"
                        },
                        new
                        {
                            Id = 6,
                            CurrencyCode = "AUD",
                            CurrencyName = "Australian Dollar",
                            CurrencySymbol = "$"
                        });
                });

            modelBuilder.Entity("Transactly.Data.Models.ExchangeRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BaseCurrencyId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<int>("TargetCurrencyId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BaseCurrencyId");

                    b.HasIndex("TargetCurrencyId");

                    b.ToTable("ExchangeRates");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BaseCurrencyId = 1,
                            Rate = 0.54m,
                            TargetCurrencyId = 2
                        },
                        new
                        {
                            Id = 2,
                            BaseCurrencyId = 1,
                            Rate = 0.51m,
                            TargetCurrencyId = 3
                        },
                        new
                        {
                            Id = 3,
                            BaseCurrencyId = 1,
                            Rate = 0.42m,
                            TargetCurrencyId = 4
                        },
                        new
                        {
                            Id = 4,
                            BaseCurrencyId = 1,
                            Rate = 82.66m,
                            TargetCurrencyId = 5
                        },
                        new
                        {
                            Id = 5,
                            BaseCurrencyId = 1,
                            Rate = 0.84m,
                            TargetCurrencyId = 6
                        },
                        new
                        {
                            Id = 6,
                            BaseCurrencyId = 2,
                            Rate = 1.86m,
                            TargetCurrencyId = 1
                        },
                        new
                        {
                            Id = 7,
                            BaseCurrencyId = 2,
                            Rate = 0.95m,
                            TargetCurrencyId = 3
                        },
                        new
                        {
                            Id = 8,
                            BaseCurrencyId = 2,
                            Rate = 0.79m,
                            TargetCurrencyId = 4
                        },
                        new
                        {
                            Id = 9,
                            BaseCurrencyId = 2,
                            Rate = 153.86m,
                            TargetCurrencyId = 5
                        },
                        new
                        {
                            Id = 10,
                            BaseCurrencyId = 2,
                            Rate = 1.57m,
                            TargetCurrencyId = 6
                        },
                        new
                        {
                            Id = 11,
                            BaseCurrencyId = 3,
                            Rate = 1.96m,
                            TargetCurrencyId = 1
                        },
                        new
                        {
                            Id = 12,
                            BaseCurrencyId = 3,
                            Rate = 1.05m,
                            TargetCurrencyId = 2
                        },
                        new
                        {
                            Id = 13,
                            BaseCurrencyId = 3,
                            Rate = 0.83m,
                            TargetCurrencyId = 4
                        },
                        new
                        {
                            Id = 14,
                            BaseCurrencyId = 3,
                            Rate = 161.67m,
                            TargetCurrencyId = 5
                        },
                        new
                        {
                            Id = 15,
                            BaseCurrencyId = 3,
                            Rate = 1.65m,
                            TargetCurrencyId = 6
                        },
                        new
                        {
                            Id = 16,
                            BaseCurrencyId = 4,
                            Rate = 2.36m,
                            TargetCurrencyId = 1
                        },
                        new
                        {
                            Id = 17,
                            BaseCurrencyId = 4,
                            Rate = 1.26m,
                            TargetCurrencyId = 2
                        },
                        new
                        {
                            Id = 18,
                            BaseCurrencyId = 4,
                            Rate = 1.20m,
                            TargetCurrencyId = 3
                        },
                        new
                        {
                            Id = 19,
                            BaseCurrencyId = 4,
                            Rate = 194.30m,
                            TargetCurrencyId = 5
                        },
                        new
                        {
                            Id = 20,
                            BaseCurrencyId = 4,
                            Rate = 1.98m,
                            TargetCurrencyId = 6
                        },
                        new
                        {
                            Id = 21,
                            BaseCurrencyId = 5,
                            Rate = 0.012m,
                            TargetCurrencyId = 1
                        },
                        new
                        {
                            Id = 22,
                            BaseCurrencyId = 5,
                            Rate = 0.0065m,
                            TargetCurrencyId = 2
                        },
                        new
                        {
                            Id = 23,
                            BaseCurrencyId = 5,
                            Rate = 0.0062m,
                            TargetCurrencyId = 3
                        },
                        new
                        {
                            Id = 24,
                            BaseCurrencyId = 5,
                            Rate = 0.0052m,
                            TargetCurrencyId = 4
                        },
                        new
                        {
                            Id = 25,
                            BaseCurrencyId = 5,
                            Rate = 0.01m,
                            TargetCurrencyId = 6
                        },
                        new
                        {
                            Id = 26,
                            BaseCurrencyId = 6,
                            Rate = 1.18m,
                            TargetCurrencyId = 1
                        },
                        new
                        {
                            Id = 27,
                            BaseCurrencyId = 6,
                            Rate = 0.64m,
                            TargetCurrencyId = 2
                        },
                        new
                        {
                            Id = 28,
                            BaseCurrencyId = 6,
                            Rate = 0.61m,
                            TargetCurrencyId = 3
                        },
                        new
                        {
                            Id = 29,
                            BaseCurrencyId = 6,
                            Rate = 0.5m,
                            TargetCurrencyId = 4
                        },
                        new
                        {
                            Id = 30,
                            BaseCurrencyId = 6,
                            Rate = 97.88m,
                            TargetCurrencyId = 5
                        });
                });

            modelBuilder.Entity("Transactly.Data.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("FromAccountId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("ToAccountId")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromAccountId");

                    b.HasIndex("ToAccountId");

                    b.HasIndex("TypeId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Transactly.Data.Models.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Type = "Deposit"
                        },
                        new
                        {
                            Id = 2,
                            Type = "Withdrawal"
                        },
                        new
                        {
                            Id = 3,
                            Type = "Transfer"
                        },
                        new
                        {
                            Id = 4,
                            Type = "Exchange"
                        },
                        new
                        {
                            Id = 5,
                            Type = "Card Payment"
                        });
                });

            modelBuilder.Entity("Transactly.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SessionToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("TokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Transactly.Data.Models.Account", b =>
                {
                    b.HasOne("Transactly.Data.Models.Currency", "Currency")
                        .WithMany("Accounts")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Transactly.Data.Models.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Transactly.Data.Models.Card", b =>
                {
                    b.HasOne("Transactly.Data.Models.Account", "Account")
                        .WithMany("Cards")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Transactly.Data.Models.ExchangeRate", b =>
                {
                    b.HasOne("Transactly.Data.Models.Currency", "BaseCurrency")
                        .WithMany("ExchangeRates")
                        .HasForeignKey("BaseCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Transactly.Data.Models.Currency", "TargetCurrency")
                        .WithMany("ExchangeCurrencyRates")
                        .HasForeignKey("TargetCurrencyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("BaseCurrency");

                    b.Navigation("TargetCurrency");
                });

            modelBuilder.Entity("Transactly.Data.Models.Transaction", b =>
                {
                    b.HasOne("Transactly.Data.Models.Account", "FromAccount")
                        .WithMany("IncomingTransactions")
                        .HasForeignKey("FromAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Transactly.Data.Models.Account", "ToAccount")
                        .WithMany("OutgoingTransactions")
                        .HasForeignKey("ToAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Transactly.Data.Models.TransactionType", "Type")
                        .WithMany("Transactions")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromAccount");

                    b.Navigation("ToAccount");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Transactly.Data.Models.Account", b =>
                {
                    b.Navigation("Cards");

                    b.Navigation("IncomingTransactions");

                    b.Navigation("OutgoingTransactions");
                });

            modelBuilder.Entity("Transactly.Data.Models.Currency", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("ExchangeCurrencyRates");

                    b.Navigation("ExchangeRates");
                });

            modelBuilder.Entity("Transactly.Data.Models.TransactionType", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Transactly.Data.Models.User", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
