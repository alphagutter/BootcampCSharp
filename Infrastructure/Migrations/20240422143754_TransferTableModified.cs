using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TransferTableModified : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Accounts_DestinationAccountId",
                table: "Movements");

            migrationBuilder.DropTable(
                name: "AccountTransfer");

            migrationBuilder.DropIndex(
                name: "IX_Movements_DestinationAccountId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Transfers");

            migrationBuilder.DropColumn(
                name: "DestinationAccountId",
                table: "Movements");

            migrationBuilder.RenameColumn(
                name: "TransferStatus",
                table: "Transfers",
                newName: "MovementId");

            migrationBuilder.AddColumn<DateTime>(
                name: "TransferredDateTime",
                table: "Movements",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_MovementId",
                table: "Transfers",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfers_OriginAccountId",
                table: "Transfers",
                column: "OriginAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_OriginAccountId",
                table: "Movements",
                column: "OriginAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Accounts_OriginAccountId",
                table: "Movements",
                column: "OriginAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Accounts_OriginAccountId",
                table: "Transfers",
                column: "OriginAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transfers_Movements_MovementId",
                table: "Transfers",
                column: "MovementId",
                principalTable: "Movements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movements_Accounts_OriginAccountId",
                table: "Movements");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Accounts_OriginAccountId",
                table: "Transfers");

            migrationBuilder.DropForeignKey(
                name: "FK_Transfers_Movements_MovementId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_MovementId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Transfers_OriginAccountId",
                table: "Transfers");

            migrationBuilder.DropIndex(
                name: "IX_Movements_OriginAccountId",
                table: "Movements");

            migrationBuilder.DropColumn(
                name: "TransferredDateTime",
                table: "Movements");

            migrationBuilder.RenameColumn(
                name: "MovementId",
                table: "Transfers",
                newName: "TransferStatus");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Transfers",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "DestinationAccountId",
                table: "Movements",
                type: "integer",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Movements_Accounts_DestinationAccountId",
                table: "Movements",
                column: "DestinationAccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
