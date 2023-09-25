using Microsoft.EntityFrameworkCore.Migrations;

namespace Liga.web.Migrations
{
    public partial class GameTemp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_AspNetUsers_UserId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_JourneyDetails_JourneyDetailId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Game_journeyDetailTemp_JourneyDetailTempId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "JourneyDetails");

            migrationBuilder.DropTable(
                name: "journeyDetailTemp");

            migrationBuilder.DropIndex(
                name: "IX_Game_JourneyDetailId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_UserId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "JourneyDetailId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "JourneyDetailTempId",
                table: "Game",
                newName: "JourneyId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_JourneyDetailTempId",
                table: "Game",
                newName: "IX_Game_JourneyId");

            migrationBuilder.AlterColumn<long>(
                name: "YellowCardB",
                table: "Game",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "YellowCardA",
                table: "Game",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RedCardB",
                table: "Game",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "RedCardA",
                table: "Game",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "GolsTeamB",
                table: "Game",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "GolsTeamA",
                table: "Game",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "GameDetailTemp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeamAId = table.Column<int>(type: "int", nullable: true),
                    TeamBId = table.Column<int>(type: "int", nullable: true),
                    GolsTeamA = table.Column<long>(type: "bigint", nullable: true),
                    GolsTeamB = table.Column<long>(type: "bigint", nullable: true),
                    YellowCardA = table.Column<long>(type: "bigint", nullable: true),
                    YellowCardB = table.Column<long>(type: "bigint", nullable: true),
                    RedCardA = table.Column<long>(type: "bigint", nullable: true),
                    RedCardB = table.Column<long>(type: "bigint", nullable: true),
                    IsConcluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameDetailTemp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GameDetailTemp_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameDetailTemp_Teams_TeamAId",
                        column: x => x.TeamAId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameDetailTemp_Teams_TeamBId",
                        column: x => x.TeamBId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameDetailTemp_TeamAId",
                table: "GameDetailTemp",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetailTemp_TeamBId",
                table: "GameDetailTemp",
                column: "TeamBId");

            migrationBuilder.CreateIndex(
                name: "IX_GameDetailTemp_UserId",
                table: "GameDetailTemp",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Journeys_JourneyId",
                table: "Game",
                column: "JourneyId",
                principalTable: "Journeys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Journeys_JourneyId",
                table: "Game");

            migrationBuilder.DropTable(
                name: "GameDetailTemp");

            migrationBuilder.RenameColumn(
                name: "JourneyId",
                table: "Game",
                newName: "JourneyDetailTempId");

            migrationBuilder.RenameIndex(
                name: "IX_Game_JourneyId",
                table: "Game",
                newName: "IX_Game_JourneyDetailTempId");

            migrationBuilder.AlterColumn<long>(
                name: "YellowCardB",
                table: "Game",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "YellowCardA",
                table: "Game",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RedCardB",
                table: "Game",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "RedCardA",
                table: "Game",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GolsTeamB",
                table: "Game",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "GolsTeamA",
                table: "Game",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JourneyDetailId",
                table: "Game",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Game",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JourneyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JourneyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JourneyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JourneyDetails_Journeys_JourneyId",
                        column: x => x.JourneyId,
                        principalTable: "Journeys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "journeyDetailTemp",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_journeyDetailTemp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_journeyDetailTemp_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Game_JourneyDetailId",
                table: "Game",
                column: "JourneyDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_UserId",
                table: "Game",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_JourneyDetails_JourneyId",
                table: "JourneyDetails",
                column: "JourneyId");

            migrationBuilder.CreateIndex(
                name: "IX_journeyDetailTemp_UserId",
                table: "journeyDetailTemp",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_AspNetUsers_UserId",
                table: "Game",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
