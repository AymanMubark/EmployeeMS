using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeMS.Migrations
{
    public partial class FixEmailColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Emaill",
                table: "Employee",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Employee",
                newName: "Emaill");
        }
    }
}
