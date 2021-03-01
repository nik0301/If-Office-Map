using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeMap.Data.Migrations
{
    public partial class renamedcolumnSuperusertoIsSuperUserinEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "super_user",
                table: "Employees",
                newName: "is_super_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "is_super_user",
                table: "Employees",
                newName: "super_user");
        }
    }
}
