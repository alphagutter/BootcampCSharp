using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductTableModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Banks_BankId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Currencies_CurrencyId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_CurrencyId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "Transfers",
                newName: "TransferStatus");

            migrationBuilder.RenameColumn(
                name: "BankId",
                table: "Transfers",
                newName: "DestinationCurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_BankId",
                table: "Transfers",
                newName: "IX_Transfers_DestinationCurrencyId");

            migrationBuilder.AddColumn<int>(
                name: "DestinationBankId",
                table: "Transfers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Petitions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_DestinationBankId",
                table: "Transfers",
                column: "DestinationBankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Banks_DestinationBankId",
                table: "Transfers",
                column: "DestinationBankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Currencies_DestinationCurrencyId",
                table: "Transfers",
                column: "DestinationCurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Banks_DestinationBankId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Currencies_DestinationCurrencyId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_DestinationBankId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "DestinationBankId",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Petitions");

            migrationBuilder.RenameColumn(
                name: "TransferStatus",
                table: "Transfers",
                newName: "CurrencyId");

            migrationBuilder.RenameColumn(
                name: "DestinationCurrencyId",
                table: "Transfers",
                newName: "BankId");

            migrationBuilder.RenameIndex(
                name: "IX_Transfers_DestinationCurrencyId",
                table: "Transfers",
                newName: "IX_Transfers_BankId");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Products",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_CurrencyId",
                table: "Transfers",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Banks_BankId",
                table: "Transfers",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Currencies_CurrencyId",
                table: "Transfers",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
