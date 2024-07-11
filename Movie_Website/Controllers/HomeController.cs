using DataLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Website.AppContext;

namespace Movie_Website.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationContext _db;
		private readonly IMovieService _movieService;
		private readonly INewsService _newsService;
		public HomeController(ApplicationContext context,IMovieService movie, INewsService newsService)
		{
			_db = context;
			_movieService = movie;
			_newsService = newsService;
		}
		[Route("/")]
		public async Task<IActionResult> Index()
		{
			TempData["Index"] = "active";


			//var c = _db.MovieMedCastModels.Include(m => m.MovieModel).Include(c => c.CastModel).ToList();
			// i use thiss
			var a = _db.MovieModels.Include(c => c.MovieMedCasts).ThenInclude(x => x.CastModel).ToList();
			var movie = await _movieService.GetMovieForSlider();

			return View(movie);
		}

		public IActionResult Details(int id)
		{
			return View(_movieService.GetMovieById(id));
		}

		public IActionResult News()
		{
			return PartialView();
		}

		public IActionResult Videos()
		{
			TempData["Videos"] = "active";
			return View(_movieService.GetAllVideos());
		}

		#region show celebrities to users
		public IActionResult ShowCelebrities()
		{
			TempData["ShowCelebrities"] = "active";
			return View(_db.CastModels.ToList());
		}
		#region Detail cast to users
		public IActionResult DetailCelebrities(int id)
		{
			var cast = _db.CastModels.SingleOrDefault(x => x.CastId == id);
			if (cast == null) return NotFound();
			return View(cast);
		}
		#endregion
		#endregion


		#region Show news
		public IActionResult LatestNews()
		{
			TempData["LatestNews"] = "active";
			return View(_newsService.GetAllNews());
		}
		#region Detail News
		public IActionResult DetailsNews(int id)
		{
			return View(_newsService.GetNewsById(id));
		}
		#endregion
		#endregion
	}
}
