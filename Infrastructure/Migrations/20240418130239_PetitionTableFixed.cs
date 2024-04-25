using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PetitionTableFixed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_CreditCards_CreditCardId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_CurrentAccounts_CurrentAccountId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CreditCardId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_CurrentAccountId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreditCardId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CurrentAccountId",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Petitions",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Petitions_ProductId",
                table: "Petitions",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_Product_ProductId",
                table: "Petitions",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_Product_ProductId",
                table: "Petitions");

            migrationBuilder.DropIndex(
                name: "IX_Petitions_ProductId",
                table: "Petitions");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Petitions");

            migrationBuilder.AddColumn<int>(
                name: "CreditCardId",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CurrentAccountId",
                table: "Product",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreditCardId",
                table: "Product",
                column: "CreditCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CurrentAccountId",
                table: "Product",
                column: "CurrentAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CreditCards_CreditCardId",
                table: "Product",
                column: "CreditCardId",
                principalTable: "CreditCards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_CurrentAccounts_CurrentAccountId",
                table: "Product",
                column: "CurrentAccountId",
                principalTable: "CurrentAccounts",
                principalColumn: "Id");
        }
    }
}
