using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeMap.Data.Migrations
{
    public partial class addedcolumnUnitIdinEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Objects]", true);
            migrationBuilder.Sql("DELETE FROM [Employees]", true);

            migrationBuilder.AddColumn<string>(
                name: "unit_id",
                table: "Employees",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_unit_id",
                table: "Employees",
                column: "unit_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Units_unit_id",
                table: "Employees",
                column: "unit_id",
                principalTable: "Units",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Units_unit_id",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_unit_id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "unit_id",
                table: "Employees");
        }
    }
}
