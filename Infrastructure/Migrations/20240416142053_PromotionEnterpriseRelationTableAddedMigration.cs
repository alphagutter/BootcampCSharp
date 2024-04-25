using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PromotionEnterpriseRelationTableAddedMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Promotions_Businesses_BusinessId",
                table: "Promotions");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropIndex(
                name: "IX_Promotions_BusinessId",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "DurationTime",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "PercentageOff",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "BusinessId",
                table: "Promotions",
                newName: "Discount");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Promotions",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Start",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Enterprises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Enterprise_pkey", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PromotionEnterprise",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PromotionId = table.Column<int>(type: "integer", nullable: false),
                    EnterpriseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionEnterprise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromotionEnterprise_Enterprises_EnterpriseId",
                        column: x => x.EnterpriseId,
                        principalTable: "Enterprises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PromotionEnterprise_Promotions_PromotionId",
                        column: x => x.PromotionId,
                        principalTable: "Promotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PromotionEnterprise_EnterpriseId",
                table: "PromotionEnterprise",
                column: "EnterpriseId");

            migrationBuilder.CreateIndex(
                name: "IX_PromotionEnterprise_PromotionId_EnterpriseId",
                table: "PromotionEnterprise",
                columns: new[] { "PromotionId", "EnterpriseId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PromotionEnterprise");

            migrationBuilder.DropTable(
                name: "Enterprises");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Promotions");

            migrationBuilder.DropColumn(
                name: "Start",
                table: "Promotions");

            migrationBuilder.RenameColumn(
                name: "Discount",
                table: "Promotions",
                newName: "BusinessId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Promotions",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "DurationTime",
                table: "Promotions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "PercentageOff",
                table: "Promotions",
                type: "numeric(20,5)",
                precision: 20,
                scale: 5,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Businesses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Business_pkey", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Promotions_BusinessId",
                table: "Promotions",
                column: "BusinessId");

            migrationBuilder.AddForeignKey(
                name: "FK_Promotions_Businesses_BusinessId",
                table: "Promotions",
                column: "BusinessId",
                principalTable: "Businesses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
