using DataLayer.Dto;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IServices
{
	public interface IMovieService
	{
		public List<MovieModel> GetAllMovies();
		public List<MovieModel> GetAllVideos();
		public MovieModel GetMovieById(int id);
		public  Task<List<MovieModel>> GetMovieForSlider(int count=6);
	}
}
