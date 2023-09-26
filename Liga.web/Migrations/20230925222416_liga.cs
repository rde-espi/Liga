using Microsoft.EntityFrameworkCore.Migrations;

namespace Liga.web.Migrations
{
    public partial class liga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameDetailTempId",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_GameDetailTempId",
                table: "Teams",
                column: "GameDetailTempId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_GameDetailTemp_GameDetailTempId",
                table: "Teams",
                column: "GameDetailTempId",
                principalTable: "GameDetailTemp",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_GameDetailTemp_GameDetailTempId",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_GameDetailTempId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "GameDetailTempId",
                table: "Teams");
        }
    }
}
