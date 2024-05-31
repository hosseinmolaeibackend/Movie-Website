using Microsoft.AspNetCore.Mvc;
using Movie_Website.AppContext;
using Movie_Website.Models;
using Movie_Website.ViewModel;

namespace Movie_Website.Areas.Admin.Controllers
{
    public class MovieController(ApplicationContext context) : AdminBaseController
    {



        // GET: MovieController
        public ActionResult Index()
        {
            return View(context.MovieModels.ToList());
        }

        // GET: MovieController/Details/5
        public ActionResult Details(int id)
        {
            var Movie = context.MovieModels.SingleOrDefault(x => x.MovieId == id);
            if (Movie != null)
            {
                return View(Movie);
            }
            return Json(" !--------- 😒 Notfound Movie 😒 ---------! ");
        }

        #region Create Movie
        // GET: MovieController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MovieViewModel movieVM)
        {
            if (ModelState.IsValid)
            {
                var Movie = context.MovieModels.Any(x => x.MovieTitle == movieVM.MovieTitle);
                if (!Movie)
                {
                    var newMovie = new MovieModel()
                    {
                        MovieTitle = movieVM.MovieTitle,
                        MovieDescription = movieVM.MovieDescription,
                        Author = movieVM.Author,
                        Url = movieVM.Url
                    };
                    context.MovieModels.Add(newMovie);
                    await context.SaveChangesAsync();
                    TempData["name"] = movieVM.MovieTitle;
                    TempData["message"] = "Add to Website";
                    return RedirectToAction("Index", "Movie");
                }
                else
                {
                    return Json("The Title is Exist");
                }

            }
            return Json(" !--------- 😒 Errorr 😒 ---------! ");
        }
        #endregion

        #region Edit

        // GET: MovieController/Edit/5
        public ActionResult Edit(int id)
        {
            var existMovie = context.MovieModels.SingleOrDefault(x => x.MovieId == id);
            if (existMovie == null) return NotFound();
            var editMovie = new EditMovieModel
            {
                MovieId = existMovie.MovieId,
                MovieTitle = existMovie.MovieTitle,
                Author= existMovie.Author,
                Url = existMovie.Url,
                MovieDescription= existMovie.MovieDescription
            };
            return View(editMovie);
        }

        // POST: MovieController/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EditMovieModel editMovieModel)
        {
            var ExistMovie = context.MovieModels.SingleOrDefault(x => x.MovieId == id);
            if (ExistMovie == null) return NotFound();
            if (ModelState.IsValid)
            {
                ExistMovie.MovieTitle = editMovieModel.MovieTitle;
                ExistMovie.MovieDescription = editMovieModel.MovieDescription;
                ExistMovie.Author = editMovieModel.Author;
                ExistMovie.Url = editMovieModel.Url;
                ExistMovie.MovieId = editMovieModel.MovieId;

                context.MovieModels.Update(ExistMovie);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return Json(" !--------- 😒 Errorr 😒 ---------! ");
        }
        #endregion
        // GET: MovieController/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var Movie = context.MovieModels.SingleOrDefault(x => x.MovieId == id);
            if (Movie == null) return NotFound();
            context.MovieModels.Remove(Movie);
            context.SaveChanges();
            return Json(new { success = true });
        }

      
    }
}
