using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class AddDoctorID_DoctorStatusSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "DoctorStatusSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorStatusSettings_DoctorID",
                table: "DoctorStatusSettings",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorStatusSettings_DoctorDetails_DoctorID",
                table: "DoctorStatusSettings",
                column: "DoctorID",
                principalTable: "DoctorDetails",
                principalColumn: "DoctorDetailsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorStatusSettings_DoctorDetails_DoctorID",
                table: "DoctorStatusSettings");

            migrationBuilder.DropIndex(
                name: "IX_DoctorStatusSettings_DoctorID",
                table: "DoctorStatusSettings");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "DoctorStatusSettings");
        }
    }
}
