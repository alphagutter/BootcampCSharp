using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccountTransferRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Accounts_AccountId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_Product_ProductId",
                table: "Petitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Customers_CustomerId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Movements_AccountId",
                table: "Movements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Petitions");

            migrationBuilder.DropColumn(
                name: "Term",
                table: "Petitions");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "TransferredDateTime",
                table: "Movements");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "TransferStatus",
                table: "Movements",
                newName: "OriginAccountId");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Movements",
                newName: "MovementType");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CustomerId",
                table: "Products",
                newName: "IX_Products_CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Petitions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movements",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "DestinationAccountId",
                table: "Movements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ActualOperationalLimit",
                table: "CurrentAccounts",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "Product_pkey",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Transfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TransferStatus = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    OriginAccountId = table.Column<int>(type: "integer", nullable: false),
                    DestinationAccountId = table.Column<int>(type: "integer", nullable: false),
                    TransferredDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Transfer_pkey", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfers_Accounts_DestinationAccountId",
                        column: x => x.DestinationAccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountTransfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    TransferId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTransfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTransfer_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTransfer_Transfers_TransferId",
                        column: x => x.TransferId,
                        principalTable: "Transfers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movements_DestinationAccountId",
                table: "Movements",
                column: "DestinationAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfer_AccountId",
                table: "AccountTransfer",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTransfer_TransferId",
                table: "AccountTransfer",
                column: "TransferId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_DestinationAccountId",
                table: "Transfers",
                column: "DestinationAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Accounts_DestinationAccountId",
                table: "Movements",
                column: "DestinationAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_Products_ProductId",
                table: "Petitions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Accounts_DestinationAccountId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_Products_ProductId",
                table: "Petitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Customers_CustomerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "AccountTransfer");

            migrationBuilder.DropTable(
                name: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Movements_DestinationAccountId",
                table: "Movements");

            migrationBuilder.DropPrimaryKey(
                name: "Product_pkey",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "DestinationAccountId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "ActualOperationalLimit",
                table: "CurrentAccounts");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "OriginAccountId",
                table: "Movements",
                newName: "TransferStatus");

            migrationBuilder.RenameColumn(
                name: "MovementType",
                table: "Movements",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CustomerId",
                table: "Product",
                newName: "IX_Product_CustomerId");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Petitions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Petitions",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "Term",
                table: "Petitions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Movements",
                type: "character varying(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferredDateTime",
                table: "Movements",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_AccountId",
                table: "Movements",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Accounts_AccountId",
                table: "Movements",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_Product_ProductId",
                table: "Petitions",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Customers_CustomerId",
                table: "Product",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");
        }
    }
}
