using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBoarding.Migrations
{
    public partial class changeNameToFirstname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "People",
                newName: "Firstname");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Firstname",
                table: "People",
                newName: "Name");
        }
    }
}
