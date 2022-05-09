using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class AddColumn1_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProcessID",
                table: "ProductProcessEmployees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProductProcessEmployees_ProcessID",
                table: "ProductProcessEmployees",
                column: "ProcessID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductProcessEmployees_ProcessMasters_ProcessID",
                table: "ProductProcessEmployees",
                column: "ProcessID",
                principalTable: "ProcessMasters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductProcessEmployees_ProcessMasters_ProcessID",
                table: "ProductProcessEmployees");

            migrationBuilder.DropIndex(
                name: "IX_ProductProcessEmployees_ProcessID",
                table: "ProductProcessEmployees");

            migrationBuilder.DropColumn(
                name: "ProcessID",
                table: "ProductProcessEmployees");
        }
    }
}
