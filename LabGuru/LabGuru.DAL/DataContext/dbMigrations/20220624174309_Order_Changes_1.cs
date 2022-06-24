using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class Order_Changes_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "OrderDetails",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "OrderDetails");
        }
    }
}
