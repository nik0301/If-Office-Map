using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeMap.Data.Migrations
{
    public partial class createunittable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "unit_id",
                table: "Objects",
                maxLength: 10,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 10, nullable: false),
                    name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Units_unit_id",
                table: "Objects");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Objects_unit_id",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "unit_id",
                table: "Objects");
        }
    }
}
