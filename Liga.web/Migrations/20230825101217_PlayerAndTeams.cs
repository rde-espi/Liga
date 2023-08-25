using Microsoft.EntityFrameworkCore.Migrations;

namespace Liga.web.Migrations
{
    public partial class PlayerAndTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_TeamEntity_PlayerTeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeamEntity",
                table: "TeamEntity");

            migrationBuilder.RenameTable(
                name: "TeamEntity",
                newName: "Teams");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Players",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Salary",
                table: "Players",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Teams",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_PlayerTeamId",
                table: "Players",
                column: "PlayerTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_PlayerTeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Salary",
                table: "Players");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "TeamEntity");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TeamEntity",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeamEntity",
                table: "TeamEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_TeamEntity_PlayerTeamId",
                table: "Players",
                column: "PlayerTeamId",
                principalTable: "TeamEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
