using Movie_Website.Domain.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Website.Application.Services.IServices
{
	public interface IMovieService
	{
		public List<MovieModel> GetAllMovies();
		public List<MovieModel> GetAllVideos();
		public MovieModel GetMovieById(int id);
		public Task<List<MovieModel>> GetMovieForSlider(int count = 6);
		public Task<List<MovieModel>> GetTopMovies();
	}
}
