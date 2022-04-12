using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class ClinicLabMap_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorLabMappings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ClinicID = table.Column<int>(type: "int", nullable: false),
                    LabID = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorLabMappings", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorLabMappings_DoctorClinics_ClinicID",
                        column: x => x.ClinicID,
                        principalTable: "DoctorClinics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorLabMappings_Laboratories_LabID",
                        column: x => x.LabID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLabMappings_ClinicID",
                table: "DoctorLabMappings",
                column: "ClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorLabMappings_LabID",
                table: "DoctorLabMappings",
                column: "LabID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorLabMappings");
        }
    }
}
