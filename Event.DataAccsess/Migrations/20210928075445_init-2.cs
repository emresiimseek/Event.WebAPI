using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.DataAccsess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserUsers",
                columns: table => new
                {
                    UserChildId = table.Column<int>(nullable: false),
                    UserParentId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    ModifiedBy = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserUsers", x => new { x.UserParentId, x.UserChildId });
                    table.ForeignKey(
                        name: "FK_UserUsers_Users_UserChildId",
                        column: x => x.UserChildId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserUsers_Users_UserParentId",
                        column: x => x.UserParentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserUsers_UserChildId",
                table: "UserUsers",
                column: "UserChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUsers");
        }
    }
}
