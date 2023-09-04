using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Liga.web.Migrations
{
    public partial class ImageId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathLogo",
                table: "Teams");

            migrationBuilder.AddColumn<Guid>(
                name: "ImageId",
                table: "Teams",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Teams");

            migrationBuilder.AddColumn<string>(
                name: "PathLogo",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
