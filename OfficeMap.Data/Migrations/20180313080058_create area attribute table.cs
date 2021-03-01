using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeMap.Data.Migrations
{
    public partial class createareaattributetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreasAttributes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    area_id = table.Column<int>(nullable: false),
                    attribute_id = table.Column<int>(nullable: false),
                    value = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasAttributes", x => x.id);
                    table.ForeignKey(
                        name: "FK_AreasAttributes_Areas_area_id",
                        column: x => x.area_id,
                        principalTable: "Areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreasAttributes_Attributes_attribute_id",
                        column: x => x.attribute_id,
                        principalTable: "Attributes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreasAttributes_area_id",
                table: "AreasAttributes",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_AreasAttributes_attribute_id",
                table: "AreasAttributes",
                column: "attribute_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreasAttributes");
        }
    }
}
