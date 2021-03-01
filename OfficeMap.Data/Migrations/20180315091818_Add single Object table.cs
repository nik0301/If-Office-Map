using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OfficeMap.Data.Migrations
{
    public partial class AddsingleObjecttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "area_id",
                table: "ObjectAttributes",
                newName: "object_id");

            migrationBuilder.AddColumn<int>(
                name: "height",
                table: "SvgTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "width",
                table: "SvgTypes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "attribute_id",
                table: "ObjectAttributes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Objects",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    custom_height = table.Column<int>(nullable: true),
                    custom_width = table.Column<int>(nullable: true),
                    employee_id = table.Column<int>(nullable: true),
                    floor_id = table.Column<int>(nullable: false),
                    object_type = table.Column<string>(maxLength: 10, nullable: true),
                    parent_object_id = table.Column<int>(nullable: true),
                    rotation_angle = table.Column<int>(nullable: true),
                    svg_type_id = table.Column<string>(nullable: true),
                    top_left_x = table.Column<int>(nullable: false),
                    top_left_y = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objects", x => x.id);
                    table.ForeignKey(
                        name: "FK_Objects_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objects_Floors_floor_id",
                        column: x => x.floor_id,
                        principalTable: "Floors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Objects_Objects_parent_object_id",
                        column: x => x.parent_object_id,
                        principalTable: "Objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Objects_SvgTypes_svg_type_id",
                        column: x => x.svg_type_id,
                        principalTable: "SvgTypes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectAttributes_attribute_id",
                table: "ObjectAttributes",
                column: "attribute_id");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectAttributes_object_id",
                table: "ObjectAttributes",
                column: "object_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_employee_id",
                table: "Objects",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_floor_id",
                table: "Objects",
                column: "floor_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_parent_object_id",
                table: "Objects",
                column: "parent_object_id");

            migrationBuilder.CreateIndex(
                name: "IX_Objects_svg_type_id",
                table: "Objects",
                column: "svg_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectAttributes_Attributes_attribute_id",
                table: "ObjectAttributes",
                column: "attribute_id",
                principalTable: "Attributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectAttributes_Objects_object_id",
                table: "ObjectAttributes",
                column: "object_id",
                principalTable: "Objects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectAttributes_Attributes_attribute_id",
                table: "ObjectAttributes");

            migrationBuilder.DropForeignKey(
                name: "FK_ObjectAttributes_Objects_object_id",
                table: "ObjectAttributes");

            migrationBuilder.DropTable(
                name: "Objects");

            migrationBuilder.DropIndex(
                name: "IX_ObjectAttributes_attribute_id",
                table: "ObjectAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ObjectAttributes_object_id",
                table: "ObjectAttributes");

            migrationBuilder.DropColumn(
                name: "height",
                table: "SvgTypes");

            migrationBuilder.DropColumn(
                name: "width",
                table: "SvgTypes");

            migrationBuilder.RenameColumn(
                name: "object_id",
                table: "ObjectAttributes",
                newName: "area_id");

            migrationBuilder.AlterColumn<string>(
                name: "attribute_id",
                table: "ObjectAttributes",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
