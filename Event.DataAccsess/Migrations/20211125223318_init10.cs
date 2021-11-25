using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.DataAccsess.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ActivityLikes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "ActivityLikes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ActivityLikes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedAt",
                table: "ActivityLikes",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ModifiedBy",
                table: "ActivityLikes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "ActivityLikes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ActivityLikes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ActivityLikes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ActivityLikes");

            migrationBuilder.DropColumn(
                name: "ModifiedAt",
                table: "ActivityLikes");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "ActivityLikes");

            migrationBuilder.DropColumn(
                name: "State",
                table: "ActivityLikes");
        }
    }
}
