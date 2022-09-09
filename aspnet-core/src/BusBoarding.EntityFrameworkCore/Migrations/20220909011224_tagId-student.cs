using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBoarding.Migrations
{
    public partial class tagIdstudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagId",
                table: "People");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TagId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
