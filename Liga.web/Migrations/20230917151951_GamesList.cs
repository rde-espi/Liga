using Microsoft.EntityFrameworkCore.Migrations;

namespace Liga.web.Migrations
{
    public partial class GamesList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JourneyDetails_Game_GameId",
                table: "JourneyDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_journeyDetailTemp_Game_GameId",
                table: "journeyDetailTemp");

            migrationBuilder.DropIndex(
                name: "IX_journeyDetailTemp_GameId",
                table: "journeyDetailTemp");

            migrationBuilder.DropIndex(
                name: "IX_JourneyDetails_GameId",
                table: "JourneyDetails");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "journeyDetailTemp");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "JourneyDetails");

            migrationBuilder.AddColumn<int>(
                name: "JourneyDetailId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JourneyDetailTempId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_JourneyDetailId",
                table: "Game",
                column: "JourneyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_JourneyDetailTempId",
                table: "Game",
                column: "JourneyDetailTempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_JourneyDetails_JourneyDetailId",
                table: "Game",
                column: "JourneyDetailId",
                principalTable: "JourneyDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Game_journeyDetailTemp_JourneyDetailTempId",
                table: "Game",
                column: "JourneyDetailTempId",
                principalTable: "journeyDetailTemp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_JourneyDetails_JourneyDetailId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_journeyDetailTemp_JourneyDetailTempId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_JourneyDetailId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_JourneyDetailTempId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "JourneyDetailId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "JourneyDetailTempId",
                table: "Game");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "journeyDetailTemp",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "JourneyDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_journeyDetailTemp_GameId",
                table: "journeyDetailTemp",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyDetails_GameId",
                table: "JourneyDetails",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_JourneyDetails_Game_GameId",
                table: "JourneyDetails",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_journeyDetailTemp_Game_GameId",
                table: "journeyDetailTemp",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
