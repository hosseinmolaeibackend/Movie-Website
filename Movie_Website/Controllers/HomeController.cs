using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_Website.AppContext;

namespace Movie_Website.Controllers
{
	public class HomeController : Controller
	{
		private readonly ApplicationContext _db;
		public HomeController(ApplicationContext context)
		{
			_db = context;
		}
		[Route("/")]
		public IActionResult Index()
		{
			TempData["Index"] = "active";
			return View(_db.MovieModels.ToList());
		}

		public IActionResult Details(int id)
		{
			var Movie = _db.MovieModels.Include(x => x.comments).ThenInclude(x => x.User).SingleOrDefault(p => p.MovieId == id);
			if (Movie == null) return NotFound();
			return View(Movie);
		}

		public IActionResult News()
		{
			return PartialView();
		}

		public IActionResult Videos()
		{
			TempData["Videos"] = "active";
			var videos = _db.MovieModels.Include(x => x.comments).ToList();
			return View(videos);
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
	}
}
