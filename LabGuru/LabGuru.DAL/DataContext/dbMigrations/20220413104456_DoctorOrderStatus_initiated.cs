using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class DoctorOrderStatus_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DoctorStatusSettings",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DoctorClinicID = table.Column<int>(type: "int", nullable: false),
                    StatusMasterID = table.Column<int>(type: "int", nullable: false),
                    Include = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ShowToDoctor = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorStatusSettings", x => x.id);
                    table.ForeignKey(
                        name: "FK_DoctorStatusSettings_DoctorClinics_DoctorClinicID",
                        column: x => x.DoctorClinicID,
                        principalTable: "DoctorClinics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DoctorStatusSettings_OrderStatusMasters_StatusMasterID",
                        column: x => x.StatusMasterID,
                        principalTable: "OrderStatusMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorStatusSettings_DoctorClinicID",
                table: "DoctorStatusSettings",
                column: "DoctorClinicID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorStatusSettings_StatusMasterID",
                table: "DoctorStatusSettings",
                column: "StatusMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorStatusSettings");
        }
    }
}
