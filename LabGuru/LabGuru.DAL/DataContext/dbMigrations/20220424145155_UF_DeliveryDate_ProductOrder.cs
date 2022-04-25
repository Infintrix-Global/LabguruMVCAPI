using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class UF_DeliveryDate_ProductOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "ProductOrders",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "ProductOrders");
        }
    }
}
