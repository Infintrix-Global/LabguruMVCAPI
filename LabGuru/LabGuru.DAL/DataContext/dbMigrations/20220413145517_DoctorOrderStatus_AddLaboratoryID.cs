using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class DoctorOrderStatus_AddLaboratoryID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LaboratoryID",
                table: "DoctorStatusSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorStatusSettings_LaboratoryID",
                table: "DoctorStatusSettings",
                column: "LaboratoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorStatusSettings_Laboratories_LaboratoryID",
                table: "DoctorStatusSettings",
                column: "LaboratoryID",
                principalTable: "Laboratories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorStatusSettings_Laboratories_LaboratoryID",
                table: "DoctorStatusSettings");

            migrationBuilder.DropIndex(
                name: "IX_DoctorStatusSettings_LaboratoryID",
                table: "DoctorStatusSettings");

            migrationBuilder.DropColumn(
                name: "LaboratoryID",
                table: "DoctorStatusSettings");
        }
    }
}
