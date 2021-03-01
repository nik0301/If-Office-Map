using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace OfficeMap.Data.Migrations
{
    public partial class RenameNrtoSeqinFloor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nr",
                table: "Floors",
                newName: "seq");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "seq",
                table: "Floors",
                newName: "nr");
        }
    }
}
