using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OfficeMap.Data.Migrations
{
    public partial class ChangedOldWorkplacefieldinWorkplaceChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkplacesChanges_Objects_old_workplace_id",
                table: "WorkplacesChanges");

            migrationBuilder.AlterColumn<int>(
                name: "old_workplace_id",
                table: "WorkplacesChanges",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_WorkplacesChanges_Objects_old_workplace_id",
                table: "WorkplacesChanges",
                column: "old_workplace_id",
                principalTable: "Objects",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkplacesChanges_Objects_old_workplace_id",
                table: "WorkplacesChanges");

            migrationBuilder.AlterColumn<int>(
                name: "old_workplace_id",
                table: "WorkplacesChanges",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkplacesChanges_Objects_old_workplace_id",
                table: "WorkplacesChanges",
                column: "old_workplace_id",
                principalTable: "Objects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
