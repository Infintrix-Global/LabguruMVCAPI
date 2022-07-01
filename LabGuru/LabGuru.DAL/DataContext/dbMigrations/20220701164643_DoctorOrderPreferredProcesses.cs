using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class DoctorOrderPreferredProcesses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "SubProcessMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ProcessMasters",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "ProcessMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DoctorOrderPreferredProcesses",
                columns: table => new
                {
                    DoctorOrderPeferredProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(type: "int", nullable: true),
                    ProcessID = table.Column<int>(type: "int", nullable: true),
                    IsCompleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Remarks = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorOrderPreferredProcesses", x => x.DoctorOrderPeferredProcessID);
                    table.ForeignKey(
                        name: "FK_DoctorOrderPreferredProcesses_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorOrderPreferredProcesses_ProcessMasters_ProcessID",
                        column: x => x.ProcessID,
                        principalTable: "ProcessMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorOrderPreferredProcesses_OrderID",
                table: "DoctorOrderPreferredProcesses",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorOrderPreferredProcesses_ProcessID",
                table: "DoctorOrderPreferredProcesses",
                column: "ProcessID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorOrderPreferredProcesses");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "SubProcessMasters");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ProcessMasters");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "ProcessMasters");
        }
    }
}
