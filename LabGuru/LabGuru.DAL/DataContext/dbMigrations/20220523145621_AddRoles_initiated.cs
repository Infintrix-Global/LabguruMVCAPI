using Microsoft.EntityFrameworkCore.Migrations;

namespace LabGuru.DAL.DataContext.dbMigrations
{
    public partial class AddRoles_initiated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<bool>(
            //    name: "IsActive",
            //    table: "Roles",
            //    type: "tinyint(1)",
            //    nullable: false,
            //    defaultValue: false);

            //migrationBuilder.AlterColumn<int>(
            //    name: "RoleID",
            //    table: "MenuRights",
            //    type: "int",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(50)",
            //    oldMaxLength: 50);

            //migrationBuilder.AlterColumn<int>(
            //    name: "RoleID",
            //    table: "Logins",
            //    type: "int",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(string),
            //    oldType: "varchar(50)",
            //    oldMaxLength: 50);

            //migrationBuilder.CreateIndex(
            //    name: "IX_MenuRights_RoleID",
            //    table: "MenuRights",
            //    column: "RoleID");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Logins_RoleID",
            //    table: "Logins",
            //    column: "RoleID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Logins_Roles_RoleID",
            //    table: "Logins",
            //    column: "RoleID",
            //    principalTable: "Roles",
            //    principalColumn: "RoleID",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_MenuRights_Roles_RoleID",
            //    table: "MenuRights",
            //    column: "RoleID",
            //    principalTable: "Roles",
            //    principalColumn: "RoleID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Logins_Roles_RoleID",
            //    table: "Logins");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_MenuRights_Roles_RoleID",
            //    table: "MenuRights");

            //migrationBuilder.DropIndex(
            //    name: "IX_MenuRights_RoleID",
            //    table: "MenuRights");

            //migrationBuilder.DropIndex(
            //    name: "IX_Logins_RoleID",
            //    table: "Logins");

            //migrationBuilder.DropColumn(
            //    name: "IsActive",
            //    table: "Roles");

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleID",
            //    table: "MenuRights",
            //    type: "varchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldMaxLength: 50);

            //migrationBuilder.AlterColumn<string>(
            //    name: "RoleID",
            //    table: "Logins",
            //    type: "varchar(50)",
            //    maxLength: 50,
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldMaxLength: 50);
        }
    }
}
