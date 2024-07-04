using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Website.Migrations
{
    /// <inheritdoc />
    public partial class updateCastAndMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "MovieModels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoName",
                table: "MovieModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "CastModels",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "VideoName",
                table: "MovieModels");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "CastModels");
        }
    }
}
