using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.DataAccsess.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdentityNumber",
                table: "User");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "User",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Token",
                table: "User");

            migrationBuilder.AddColumn<int>(
                name: "IdentityNumber",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
