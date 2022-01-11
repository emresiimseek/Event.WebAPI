using Microsoft.EntityFrameworkCore.Migrations;

namespace Event.DataAccsess.Migrations
{
    public partial class init14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommentComments",
                columns: table => new
                {
                    CommentChildId = table.Column<int>(nullable: false),
                    CommentParentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentComments", x => new { x.CommentParentId, x.CommentChildId });
                    table.ForeignKey(
                        name: "FK_CommentComments_Comments_CommentChildId",
                        column: x => x.CommentChildId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentComments_Comments_CommentParentId",
                        column: x => x.CommentParentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentComments_CommentChildId",
                table: "CommentComments",
                column: "CommentChildId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentComments");
        }
    }
}
