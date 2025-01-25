using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Website.Migrations
{
    /// <inheritdoc />
    public partial class update_Cast_Movie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "MovieModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseDate",
                table: "MovieModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EyeColor",
                table: "CastModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HairColor",
                table: "CastModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "CastModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "ReleaseDate",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "EyeColor",
                table: "CastModels");

            migrationBuilder.DropColumn(
                name: "HairColor",
                table: "CastModels");

            migrationBuilder.DropColumn(
                name: "Language",
                table: "CastModels");
        }
    }
}
