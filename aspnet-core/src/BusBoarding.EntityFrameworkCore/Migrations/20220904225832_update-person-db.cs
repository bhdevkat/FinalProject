using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusBoarding.Migrations
{
    public partial class updatepersondb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logitude",
                table: "Locations",
                newName: "Longitude");

            migrationBuilder.RenameColumn(
                name: "Latidute",
                table: "Locations",
                newName: "Latitude");

            migrationBuilder.AddColumn<byte[]>(
                name: "LogoImage",
                table: "People",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LogoImageType",
                table: "People",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "People",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoImage",
                table: "People");

            migrationBuilder.DropColumn(
                name: "LogoImageType",
                table: "People");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "People");

            migrationBuilder.RenameColumn(
                name: "Longitude",
                table: "Locations",
                newName: "Logitude");

            migrationBuilder.RenameColumn(
                name: "Latitude",
                table: "Locations",
                newName: "Latidute");
        }
    }
}
