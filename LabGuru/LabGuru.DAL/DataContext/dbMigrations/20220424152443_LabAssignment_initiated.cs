using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class LabAssignment_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LabAssignments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(type: "int", nullable: false),
                    ParentLabID = table.Column<int>(type: "int", nullable: false),
                    ChildLabID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LabAssignments", x => x.id);
                    table.ForeignKey(
                        name: "FK_LabAssignments_Laboratories_ChildLabID",
                        column: x => x.ChildLabID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabAssignments_Laboratories_ParentLabID",
                        column: x => x.ParentLabID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LabAssignments_OrderDetails_OrderID",
                        column: x => x.OrderID,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LabAssignments_ChildLabID",
                table: "LabAssignments",
                column: "ChildLabID");

            migrationBuilder.CreateIndex(
                name: "IX_LabAssignments_OrderID",
                table: "LabAssignments",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_LabAssignments_ParentLabID",
                table: "LabAssignments",
                column: "ParentLabID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LabAssignments");
        }
    }
}
