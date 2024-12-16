using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactly.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameExchangeRateColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_CurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_ExchangeCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.RenameColumn(
                name: "ExchangeCurrencyId",
                table: "ExchangeRates",
                newName: "TargetCurrencyId");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "ExchangeRates",
                newName: "BaseCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExchangeRates_ExchangeCurrencyId",
                table: "ExchangeRates",
                newName: "IX_ExchangeRates_TargetCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExchangeRates_CurrencyId",
                table: "ExchangeRates",
                newName: "IX_ExchangeRates_BaseCurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_BaseCurrencyId",
                table: "ExchangeRates",
                column: "BaseCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_TargetCurrencyId",
                table: "ExchangeRates",
                column: "TargetCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_BaseCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.DropForeignKey(
                name: "FK_ExchangeRates_Currencies_TargetCurrencyId",
                table: "ExchangeRates");

            migrationBuilder.RenameColumn(
                name: "TargetCurrencyId",
                table: "ExchangeRates",
                newName: "ExchangeCurrencyId");

            migrationBuilder.RenameColumn(
                name: "BaseCurrencyId",
                table: "ExchangeRates",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExchangeRates_TargetCurrencyId",
                table: "ExchangeRates",
                newName: "IX_ExchangeRates_ExchangeCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_ExchangeRates_BaseCurrencyId",
                table: "ExchangeRates",
                newName: "IX_ExchangeRates_CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_CurrencyId",
                table: "ExchangeRates",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExchangeRates_Currencies_ExchangeCurrencyId",
                table: "ExchangeRates",
                column: "ExchangeCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
