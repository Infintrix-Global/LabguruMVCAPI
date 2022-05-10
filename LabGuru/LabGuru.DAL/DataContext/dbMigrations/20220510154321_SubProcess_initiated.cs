using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class SubProcess_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubProcessMasters",
                columns: table => new
                {
                    SubProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProcessID = table.Column<int>(type: "int", nullable: false),
                    SubProcessName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProcessMasters", x => x.SubProcessID);
                    table.ForeignKey(
                        name: "FK_SubProcessMasters_ProcessMasters_ProcessID",
                        column: x => x.ProcessID,
                        principalTable: "ProcessMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubProcessEmployees",
                columns: table => new
                {
                    SubProcessEmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SubProcessID = table.Column<int>(type: "int", nullable: false),
                    LabEmployeeID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubProcessEmployees", x => x.SubProcessEmployeeID);
                    table.ForeignKey(
                        name: "FK_SubProcessEmployees_LabEmployees_LabEmployeeID",
                        column: x => x.LabEmployeeID,
                        principalTable: "LabEmployees",
                        principalColumn: "LabEmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubProcessEmployees_SubProcessMasters_SubProcessID",
                        column: x => x.SubProcessID,
                        principalTable: "SubProcessMasters",
                        principalColumn: "SubProcessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubProcessEmployees_LabEmployeeID",
                table: "SubProcessEmployees",
                column: "LabEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProcessEmployees_SubProcessID",
                table: "SubProcessEmployees",
                column: "SubProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_SubProcessMasters_ProcessID",
                table: "SubProcessMasters",
                column: "ProcessID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubProcessEmployees");

            migrationBuilder.DropTable(
                name: "SubProcessMasters");
        }
    }
}
