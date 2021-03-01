using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OfficeMap.Data.Migrations
{
    public partial class DropObjectsandAreas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Areas_workplace_id",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectAttributes_Areas_area_id",
                table: "ObjectAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectAttributes_Attributes_attribute_id",
                table: "ObjectAttributes");

            migrationBuilder.DropTable(
                name: "Objects");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropIndex(
                name: "IX_ObjectAttributes_area_id",
                table: "ObjectAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ObjectAttributes_attribute_id",
                table: "ObjectAttributes");

            migrationBuilder.DropIndex(
                name: "IX_Employees_workplace_id",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "workplace_id",
                table: "Employees");

            migrationBuilder.AlterColumn<string>(
                name: "attribute_id",
                table: "ObjectAttributes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "attribute_id",
                table: "ObjectAttributes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "workplace_id",
                table: "Employees",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    floor_id = table.Column<int>(nullable: false),
                    height = table.Column<int>(nullable: false),
                    parent_id = table.Column<int>(nullable: true),
                    top_left_x = table.Column<int>(nullable: false),
                    top_left_y = table.Column<int>(nullable: false),
                    width = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.id);
                    table.ForeignKey(
                        name: "FK_Areas_Floors_floor_id",
                        column: x => x.floor_id,
                        principalTable: "Floors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Areas_Areas_parent_id",
                        column: x => x.parent_id,
                        principalTable: "Areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    area_id = table.Column<int>(nullable: false),
                    svg_type_id = table.Column<string>(nullable: true),
                    top_left_x = table.Column<int>(nullable: false),
                    top_left_y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Objects_Areas_area_id",
                        column: x => x.area_id,
                        principalTable: "Areas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objects_SvgTypes_svg_type_id",
                        column: x => x.svg_type_id,
                        principalTable: "SvgTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectAttributes_area_id",
                table: "ObjectAttributes",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectAttributes_attribute_id",
                table: "ObjectAttributes",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_workplace_id",
                table: "Employees",
                column: "workplace_id");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_floor_id",
                table: "Areas",
                column: "floor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_parent_id",
                table: "Areas",
                column: "parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_area_id",
                table: "Objects",
                column: "area_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_svg_type_id",
                table: "Objects",
                column: "svg_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Areas_workplace_id",
                table: "Employees",
                column: "workplace_id",
                principalTable: "Areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectAttributes_Areas_area_id",
                table: "ObjectAttributes",
                column: "area_id",
                principalTable: "Areas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectAttributes_Attributes_attribute_id",
                table: "ObjectAttributes",
                column: "attribute_id",
                principalTable: "Attributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
