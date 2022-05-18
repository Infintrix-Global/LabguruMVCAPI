using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class ProcessMaster_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID",
                table: "ProcessMasters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProcessMasters_ProductID",
                table: "ProcessMasters",
                column: "ProductID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProcessMasters_ProductTypes_ProductID",
                table: "ProcessMasters",
                column: "ProductID",
                principalTable: "ProductTypes",
                principalColumn: "ProductTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProcessMasters_ProductTypes_ProductID",
                table: "ProcessMasters");

            migrationBuilder.DropIndex(
                name: "IX_ProcessMasters_ProductID",
                table: "ProcessMasters");

            migrationBuilder.DropColumn(
                name: "ProductID",
                table: "ProcessMasters");
        }
    }
}
