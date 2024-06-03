using Microsoft.AspNetCore.Mvc;
using Movie_Website.AppContext;
using Movie_Website.Models;
using System.Diagnostics;

namespace Movie_Website.Controllers
{
    public class HomeController : Controller
    {
		private readonly ApplicationContext _db;
        public HomeController(ApplicationContext context)
        {
			_db = context;
        }

        public IActionResult Index()
        {
            return View(_db.MovieModels.ToList());
        }

        public IActionResult Details(int id)
        {
			var Movie = _db.MovieModels.SingleOrDefault(x => x.MovieId == id);
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
