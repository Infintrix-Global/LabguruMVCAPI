using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class OrderImpression_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferanceType",
                table: "Logins");

            migrationBuilder.CreateTable(
                name: "OrderImpressions",
                columns: table => new
                {
                    OrderImpressionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FilePath = table.Column<string>(type: "text", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderImpressions", x => x.OrderImpressionID);
                    table.ForeignKey(
                        name: "FK_OrderImpressions_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderImpressions_OrderID",
                table: "OrderImpressions",
                column: "OrderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderImpressions");

            migrationBuilder.AddColumn<int>(
                name: "ReferanceType",
                table: "Logins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
