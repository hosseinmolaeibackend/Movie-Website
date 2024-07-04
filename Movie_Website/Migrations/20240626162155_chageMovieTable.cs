using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Website.Migrations
{
    /// <inheritdoc />
    public partial class chageMovieTable : Migration
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
        }
    }
}
