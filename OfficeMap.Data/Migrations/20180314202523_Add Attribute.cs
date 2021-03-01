using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OfficeMap.Data.Migrations
{
    public partial class AddAttribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "attribute_id",
                table: "ObjectAttributes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Attributes",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attributes", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObjectAttributes_attribute_id",
                table: "ObjectAttributes",
                column: "attribute_id");

            migrationBuilder.AddForeignKey(
                name: "FK_ObjectAttributes_Attributes_attribute_id",
                table: "ObjectAttributes",
                column: "attribute_id",
                principalTable: "Attributes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObjectAttributes_Attributes_attribute_id",
                table: "ObjectAttributes");

            migrationBuilder.DropTable(
                name: "Attributes");

            migrationBuilder.DropIndex(
                name: "IX_ObjectAttributes_attribute_id",
                table: "ObjectAttributes");

            migrationBuilder.DropColumn(
                name: "attribute_id",
                table: "ObjectAttributes");
        }
    }
}
