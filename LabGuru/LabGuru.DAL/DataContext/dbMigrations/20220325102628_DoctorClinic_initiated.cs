using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class DoctorClinic_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            
            migrationBuilder.CreateTable(
                name: "DoctorClinics",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    ClinicName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ClinicMobileNo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    ClinicAddress = table.Column<string>(type: "text", nullable: true),
                    ClinicPincode = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true),
                    ClinicDist = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    ClinicState = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorClinics", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorClinics_Logins_UserID",
                        column: x => x.UserID,
                        principalTable: "Logins",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorClinics_UserID",
                table: "DoctorClinics",
                column: "UserID");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.DropTable(
                name: "DoctorClinics");

        }
    }
}
