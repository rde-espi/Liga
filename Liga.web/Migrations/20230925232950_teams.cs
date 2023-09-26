using Microsoft.EntityFrameworkCore.Migrations;

namespace Liga.web.Migrations
{
    public partial class teams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_GameDetailTemp_GameDetailTempId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "GameDetailTempId",
                table: "Teams",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_GameDetailTempId",
                table: "Teams",
                newName: "IX_Teams_GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Game_GameId",
                table: "Teams",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Game_GameId",
                table: "Teams");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Teams",
                newName: "GameDetailTempId");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_GameId",
                table: "Teams",
                newName: "IX_Teams_GameDetailTempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_GameDetailTemp_GameDetailTempId",
                table: "Teams",
                column: "GameDetailTempId",
                principalTable: "GameDetailTemp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
