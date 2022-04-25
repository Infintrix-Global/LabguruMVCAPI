using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class Add_DoctorID_DoctorLabMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DoctorID",
                table: "DoctorLabMappings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLabMappings_DoctorID",
                table: "DoctorLabMappings",
                column: "DoctorID");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorLabMappings_DoctorDetails_DoctorID",
                table: "DoctorLabMappings",
                column: "DoctorID",
                principalTable: "DoctorDetails",
                principalColumn: "DoctorDetailsID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorLabMappings_DoctorDetails_DoctorID",
                table: "DoctorLabMappings");

            migrationBuilder.DropIndex(
                name: "IX_DoctorLabMappings_DoctorID",
                table: "DoctorLabMappings");

            migrationBuilder.DropColumn(
                name: "DoctorID",
                table: "DoctorLabMappings");
        }
    }
}
