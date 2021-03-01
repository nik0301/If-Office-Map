using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OfficeMap.Data.Migrations
{
    public partial class MergeTypesandSvgPathintoSvgType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_Types_type_id",
                table: "Objects");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "SvgPaths");

            migrationBuilder.DropIndex(
                name: "IX_Objects_type_id",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "type_id",
                table: "Objects");

            migrationBuilder.AddColumn<string>(
                name: "svg_type_id",
                table: "Objects",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SvgTypes",
                columns: table => new
                {
                    id = table.Column<string>(maxLength: 10, nullable: false),
                    draw = table.Column<string>(maxLength: 250, nullable: false),
                    fill_color = table.Column<string>(maxLength: 7, nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: true),
                    stroke_color = table.Column<string>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SvgTypes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objects_svg_type_id",
                table: "Objects",
                column: "svg_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_SvgTypes_svg_type_id",
                table: "Objects",
                column: "svg_type_id",
                principalTable: "SvgTypes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Objects_SvgTypes_svg_type_id",
                table: "Objects");

            migrationBuilder.DropTable(
                name: "SvgTypes");

            migrationBuilder.DropIndex(
                name: "IX_Objects_svg_type_id",
                table: "Objects");

            migrationBuilder.DropColumn(
                name: "svg_type_id",
                table: "Objects");

            migrationBuilder.AddColumn<int>(
                name: "type_id",
                table: "Objects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SvgPaths",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    draw = table.Column<string>(maxLength: 250, nullable: false),
                    fill_color = table.Column<string>(maxLength: 7, nullable: false),
                    stroke_color = table.Column<string>(maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SvgPaths", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    svg_path_id = table.Column<int>(nullable: false),
                    title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.id);
                    table.ForeignKey(
                        name: "FK_Types_SvgPaths_svg_path_id",
                        column: x => x.svg_path_id,
                        principalTable: "SvgPaths",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Objects_type_id",
                table: "Objects",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Types_svg_path_id",
                table: "Types",
                column: "svg_path_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Objects_Types_type_id",
                table: "Objects",
                column: "type_id",
                principalTable: "Types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
