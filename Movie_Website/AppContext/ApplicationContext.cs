using Microsoft.EntityFrameworkCore;
using Movie_Website.Models;

namespace Movie_Website.AppContext
{
	public class ApplicationContext : DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

		public DbSet<UserModel> UserModels { get; set; }
		public DbSet<MovieModel> MovieModels { get; set; }
		public DbSet<MovieMedCastModel> MovieMedCastModels { get;set; }
		public DbSet<LikeModel> LikeModels { get; set; }
		public DbSet<GenerModel> GenerModels { get; set; }
		public DbSet<CommentModel> CommentModels { get; set; }
		public DbSet<CategoryModel> CategoryModels { get; set; }
		public DbSet<CastModel> CastModels { get; set; }
	}
}
