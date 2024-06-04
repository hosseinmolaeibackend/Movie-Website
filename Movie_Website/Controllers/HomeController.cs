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
			return View(_db.MovieModels.ToList());
		}

		public IActionResult Details(int id)
		{
			var Movie = _db.MovieModels.Include(x => x.comments).SingleOrDefault(p => p.MovieId == id);
			if (Movie == null) return NotFound();
			return View(Movie);
		}

		public IActionResult News()
		{
			return PartialView();
		}

		//public IActionResult Videos()
		//{
		//	return PartialView();
		//}

		//public IActionResult vbv()
		//{
		//	return db.caterory.Include(x => x.Movies).Take(10).ToList();
		//}

	}
}
