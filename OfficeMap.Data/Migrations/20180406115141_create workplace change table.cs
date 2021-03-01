using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace OfficeMap.Data.Migrations
{
    public partial class createworkplacechangetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkplacesChanges",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    approval_date = table.Column<DateTime>(nullable: true),
                    employee_id = table.Column<int>(nullable: false),
                    new_workplace_id = table.Column<int>(nullable: false),
                    old_workplace_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkplacesChanges", x => x.id);
                    table.ForeignKey(
                        name: "FK_WorkplacesChanges_Employees_employee_id",
                        column: x => x.employee_id,
                        principalTable: "Employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkplacesChanges_Objects_new_workplace_id",
                        column: x => x.new_workplace_id,
                        principalTable: "Objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkplacesChanges_Objects_old_workplace_id",
                        column: x => x.old_workplace_id,
                        principalTable: "Objects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkplacesChanges_employee_id",
                table: "WorkplacesChanges",
                column: "employee_id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkplacesChanges_new_workplace_id",
                table: "WorkplacesChanges",
                column: "new_workplace_id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkplacesChanges_old_workplace_id",
                table: "WorkplacesChanges",
                column: "old_workplace_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkplacesChanges");
        }
    }
}
