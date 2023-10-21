using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeMS.Migrations
{
    public partial class FixIsStillWorkingColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStillvWorking",
                table: "Employee",
                newName: "IsStillWorking");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsStillWorking",
                table: "Employee",
                newName: "IsStillvWorking");
        }
    }
}
