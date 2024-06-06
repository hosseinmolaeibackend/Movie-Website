using Microsoft.EntityFrameworkCore;
using Movie_Website.Models;

namespace Movie_Website.AppContext
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<MovieModel> MovieModels { get; set; }
        public DbSet<MovieMedCastModel> MovieMedCastModels { get; set; }
        public DbSet<LikeModel> LikeModels { get; set; }
        public DbSet<GenerModel> GenerModels { get; set; }
        public DbSet<CommentModel> CommentModels { get; set; }
        public DbSet<CategoryModel> CategoryModels { get; set; }
        public DbSet<CastModel> CastModels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region user
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.comments)
                .WithOne(c => c.User)
                .HasForeignKey(u => u.UserId);
            modelBuilder.Entity<UserModel>()
                .HasMany(u => u.like)
                .WithOne(l => l.User)
                .HasForeignKey(u => u.UserId);

            #endregion

            #region Movie
            modelBuilder.Entity<MovieModel>()
                .HasMany(u => u.comments)
                .WithOne(c => c.Movie)
                .HasForeignKey(u => u.MovieId);
            modelBuilder.Entity<MovieModel>()
                .HasMany(u => u.LikeModels)
                .WithOne(c => c.Movie)
                .HasForeignKey(u => u.MovieId);
            modelBuilder.Entity<MovieModel>()
                .HasMany(m => m.generators)
                .WithOne(g => g.Movie)
                .HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<MovieModel>()
                .HasMany(m => m.MovieMedCasts)
                .WithOne(med => med.MovieModel)
                .HasForeignKey(m => m.MovieId);
            #endregion

            #region Cast
            modelBuilder.Entity<CastModel>()
                .HasMany(c => c.MovieMedCasts)
                .WithOne(m => m.CastModel)
                .HasForeignKey(c => c.CastId);
            #endregion

            #region category
            modelBuilder.Entity<CategoryModel>()
                .HasMany(cg => cg.Generes)
                .WithOne(g => g.Category)
                .HasForeignKey(cg => cg.CategoryId);
            #endregion
        }
    }
}
