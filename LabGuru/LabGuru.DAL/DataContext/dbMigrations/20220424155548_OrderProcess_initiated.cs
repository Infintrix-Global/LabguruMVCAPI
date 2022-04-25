using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class OrderProcess_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderProcesses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ProcessMasterID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProcesses", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderProcesses_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProcesses_OrderProcessMasters_ProcessMasterID",
                        column: x => x.ProcessMasterID,
                        principalTable: "OrderProcessMasters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProcesses_OrderID",
                table: "OrderProcesses",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProcesses_ProcessMasterID",
                table: "OrderProcesses",
                column: "ProcessMasterID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProcesses");
        }
    }
}
