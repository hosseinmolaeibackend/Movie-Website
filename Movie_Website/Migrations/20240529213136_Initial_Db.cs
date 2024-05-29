using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Movie_Website.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CastModels",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastModels", x => x.CastId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryModels",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenerName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryModels", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MovieModels",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieTitle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MovieDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieModels", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "UserModels",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModels", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "GenerModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenerModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenerModels_CategoryModels_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryModels",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenerModels_MovieModels_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieModels",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieMedCastModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CastId = table.Column<int>(type: "int", nullable: false),
                    CastModelCastId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMedCastModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieMedCastModels_CastModels_CastModelCastId",
                        column: x => x.CastModelCastId,
                        principalTable: "CastModels",
                        principalColumn: "CastId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMedCastModels_MovieModels_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieModels",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentModels",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentModels", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_CommentModels_MovieModels_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieModels",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentModels_UserModels_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModels",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeModels",
                columns: table => new
                {
                    LikeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeModels", x => x.LikeId);
                    table.ForeignKey(
                        name: "FK_LikeModels_MovieModels_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieModels",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeModels_UserModels_UserId",
                        column: x => x.UserId,
                        principalTable: "UserModels",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentModels_MovieId",
                table: "CommentModels",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentModels_UserId",
                table: "CommentModels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GenerModels_CategoryId",
                table: "GenerModels",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_GenerModels_MovieId",
                table: "GenerModels",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeModels_MovieId",
                table: "LikeModels",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeModels_UserId",
                table: "LikeModels",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMedCastModels_CastModelCastId",
                table: "MovieMedCastModels",
                column: "CastModelCastId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieMedCastModels_MovieId",
                table: "MovieMedCastModels",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentModels");

            migrationBuilder.DropTable(
                name: "GenerModels");

            migrationBuilder.DropTable(
                name: "LikeModels");

            migrationBuilder.DropTable(
                name: "MovieMedCastModels");

            migrationBuilder.DropTable(
                name: "CategoryModels");

            migrationBuilder.DropTable(
                name: "UserModels");

            migrationBuilder.DropTable(
                name: "CastModels");

            migrationBuilder.DropTable(
                name: "MovieModels");
        }
    }
}
