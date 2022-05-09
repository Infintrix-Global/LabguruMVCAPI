using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class AddColumn2_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LabEmployee",
                table: "ProductProcessEmployees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessEmployees_LabEmployee",
                table: "ProductProcessEmployees",
                column: "LabEmployee");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProcessEmployees_LabEmployees_LabEmployee",
                table: "ProductProcessEmployees",
                column: "LabEmployee",
                principalTable: "LabEmployees",
                principalColumn: "LabEmployeeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProcessEmployees_LabEmployees_LabEmployee",
                table: "ProductProcessEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProductProcessEmployees_LabEmployee",
                table: "ProductProcessEmployees");

            migrationBuilder.DropColumn(
                name: "LabEmployee",
                table: "ProductProcessEmployees");
        }
    }
}
