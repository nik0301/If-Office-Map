using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OfficeMap.Data.Migrations
{
    public partial class droppedwalltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Walls");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Walls",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    end_x = table.Column<int>(nullable: false),
                    end_y = table.Column<int>(nullable: false),
                    floor_id = table.Column<int>(nullable: false),
                    start_x = table.Column<int>(nullable: false),
                    start_y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Walls", x => x.id);
                    table.ForeignKey(
                        name: "FK_Walls_Floors_floor_id",
                        column: x => x.floor_id,
                        principalTable: "Floors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Walls_floor_id",
                table: "Walls",
                column: "floor_id");
        }
    }
}
