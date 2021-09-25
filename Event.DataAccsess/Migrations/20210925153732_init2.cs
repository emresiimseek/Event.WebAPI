using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.DataAccsess.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersEvents_Activities_ActivityId",
                table: "UsersEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersEvents_Users_UserId",
                table: "UsersEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersEvents",
                table: "UsersEvents");

            migrationBuilder.RenameTable(
                name: "UsersEvents",
                newName: "UserActivities");

            migrationBuilder.RenameIndex(
                name: "IX_UsersEvents_UserId",
                table: "UserActivities",
                newName: "IX_UserActivities_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserActivities",
                table: "UserActivities",
                columns: new[] { "ActivityId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Activities_ActivityId",
                table: "UserActivities",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActivities_Users_UserId",
                table: "UserActivities",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Activities_ActivityId",
                table: "UserActivities");

            migrationBuilder.DropForeignKey(
                name: "FK_UserActivities_Users_UserId",
                table: "UserActivities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserActivities",
                table: "UserActivities");

            migrationBuilder.RenameTable(
                name: "UserActivities",
                newName: "UsersEvents");

            migrationBuilder.RenameIndex(
                name: "IX_UserActivities_UserId",
                table: "UsersEvents",
                newName: "IX_UsersEvents_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersEvents",
                table: "UsersEvents",
                columns: new[] { "ActivityId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UsersEvents_Activities_ActivityId",
                table: "UsersEvents",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersEvents_Users_UserId",
                table: "UsersEvents",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
