using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.DataAccsess.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityLikes_Categories_CategoryId",
                table: "ActivityLikes");

            migrationBuilder.DropIndex(
                name: "IX_ActivityLikes_CategoryId",
                table: "ActivityLikes");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ActivityLikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ActivityLikes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLikes_CategoryId",
                table: "ActivityLikes",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityLikes_Categories_CategoryId",
                table: "ActivityLikes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
