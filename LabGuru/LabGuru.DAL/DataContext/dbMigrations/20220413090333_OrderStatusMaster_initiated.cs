using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class OrderStatusMaster_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderStatusMasters",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    LaboratoryID = table.Column<int>(type: "int", nullable: false),
                    StatusText = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    DispalyOrder = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatusMasters", x => x.id);
                    table.ForeignKey(
                        name: "FK_OrderStatusMasters_Laboratories_LaboratoryID",
                        column: x => x.LaboratoryID,
                        principalTable: "Laboratories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderStatusMasters_LaboratoryID",
                table: "OrderStatusMasters",
                column: "LaboratoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderStatusMasters");
        }
    }
}
