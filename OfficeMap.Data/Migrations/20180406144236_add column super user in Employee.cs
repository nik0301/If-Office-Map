using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeMap.Data.Migrations
{
    public partial class addcolumnsuperuserinEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "super_user",
                table: "Employees",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "super_user",
                table: "Employees");
        }
    }
}
