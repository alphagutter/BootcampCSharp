using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MovementsTableFix2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movements");

            migrationBuilder.AddColumn<int>(
                name: "TransferType",
                table: "Transfers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransferType",
                table: "Transfers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movements",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
