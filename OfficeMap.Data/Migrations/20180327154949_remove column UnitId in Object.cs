using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeMap.Data.Migrations
{
    public partial class removecolumnUnitIdinObject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Units_unit_id",
                table: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_Objects_unit_id",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "unit_id",
                table: "Objects");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "unit_id",
                table: "Objects",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Objects_unit_id",
                table: "Objects",
                column: "unit_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Units_unit_id",
                table: "Objects",
                column: "unit_id",
                principalTable: "Units",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
