using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Movie_Website.Domain.Models.Model;
using Movie_Website.Infrastructure.AppContext;
using Movie_Website.Application.Services.IServices;

namespace Movie_Website.Infrastructure.Services.Service
{
	public class MovieService : IMovieService
	{
		private readonly ApplicationContext _db;
		public MovieService(ApplicationContext context)
		{
			_db = context;
		}
		public List<MovieModel> GetAllMovies()
		{
			return
				_db.MovieModels.Include(c => c.MovieMedCasts)
				.ThenInclude(x => x.CastModel).ToList();
		}

		public List<MovieModel> GetAllVideos() => _db.MovieModels.ToList();

		public MovieModel GetMovieById(int id)
		{
			var Movie = _db.MovieModels.SingleOrDefault(m => m.MovieId == id);
			if (Movie == null) throw new ArgumentNullException(nameof(Movie));
			return Movie;
		}

		public async Task<List<MovieModel>> GetMovieForSlider(int count = 6)
		{
			var movies = await _db.MovieModels
			   .Include(c => c.MovieMedCasts)
			   .ThenInclude(x => x.CastModel)
			   .Take(count)
			   .ToListAsync();
			return movies;
		}

		public async Task<List<MovieModel>> GetTopMovies()
		{
			var movies = await _db.MovieModels
				.Include(c => c.MovieMedCasts)
				.ThenInclude(x => x.CastModel)
				.OrderByDescending(z => z.MovieTitle)
				.Take(10)
				.ToListAsync();
			return movies;
		}
	}
}
