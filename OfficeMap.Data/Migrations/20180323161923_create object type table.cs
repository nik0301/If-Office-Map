using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeMap.Data.Migrations
{
    public partial class createobjecttypetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Objects]", true);

            migrationBuilder.RenameColumn(
                name: "object_type",
                table: "Objects",
                newName: "object_type_id");

            migrationBuilder.CreateTable(
                name: "ObjectTypes",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 10, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectTypes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objects_object_type_id",
                table: "Objects",
                column: "object_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_ObjectTypes_object_type_id",
                table: "Objects",
                column: "object_type_id",
                principalTable: "ObjectTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_ObjectTypes_object_type_id",
                table: "Objects");

            migrationBuilder.DropTable(
                name: "ObjectTypes");

            migrationBuilder.DropIndex(
                name: "IX_Objects_object_type_id",
                table: "Objects");

            migrationBuilder.RenameColumn(
                name: "object_type_id",
                table: "Objects",
                newName: "object_type");
        }
    }
}
