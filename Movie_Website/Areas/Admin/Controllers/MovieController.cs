using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Movie_Website.AppContext;
using DataLayer.Models;
using Movie_Website.Utilities;
using Movie_Website.ViewModel;
using WebApplication2.Utilities.ImageHelper;
using Movie_Website.Utilities.Tools;

namespace Movie_Website.Areas.Admin.Controllers
{
    public class MovieController(ApplicationContext context) : AdminBaseController
    {
        // GET: MovieController
        public IActionResult Index()
        {
            TempData["Movie"] = "active";
            return View(context.MovieModels.ToList());
        }

        #region Details
        // GET: MovieController/Details/5
        public IActionResult Details(int id)
        {
            var Movie = context.MovieModels.SingleOrDefault(x => x.MovieId == id);
            if (Movie != null)
            {
                return View(Movie);
            }
            return Json(" !--------- 😒 Notfound Movie 😒 ---------! ");
        }
        #endregion

        #region Create Movie
        // GET: MovieController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieController/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieViewModel movieVM)
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
                    if (movieVM.Image != null)
                    {
                        var imgname = Guid.NewGuid().ToString("N") + Path.GetExtension(movieVM.Image.FileName);
                        movieVM.Image.AddImageToServer(imgname, PathTools.MovieImageServerPath, 524, 721, PathTools.MovieImageThumbServerPath);
                        newMovie.ImageName = imgname;
                    }
                    var vidname = Guid.NewGuid().ToString("N") + Path.GetExtension(movieVM.Video.FileName);
                    await movieVM.Video.AddVideoToServer(vidname, PathTools.MovieVideoServerPath);
                    newMovie.VideoName = vidname;
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
        public IActionResult Edit(int id)
        {
            var existMovie = context.MovieModels.SingleOrDefault(x => x.MovieId == id);
            if (existMovie == null) return NotFound();
            var editMovie = new EditMovieModel
            {
                MovieId = existMovie.MovieId,
                MovieTitle = existMovie.MovieTitle,
                Author = existMovie.Author,
                Url = existMovie.Url,
                MovieDescription = existMovie.MovieDescription,
                ImageName = existMovie.ImageName,
                VideoName = existMovie.VideoName
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
                if (editMovieModel.Image != null)
                {
                    var ImgName = Guid.NewGuid().ToString("N") + Path.GetExtension(editMovieModel.Image.FileName);
                    if (ExistMovie.ImageName != null)
                    {
                        editMovieModel.Image.AddImageToServer(ImgName,
                            PathTools.MovieImageServerPath, 524, 721,
                            PathTools.MovieImageThumbServerPath, ExistMovie.ImageName);
                        ExistMovie.ImageName = ImgName;
                    }
                }
                if (editMovieModel.Video != null)
                {
                    var vidname = Guid.NewGuid().ToString("N") + Path.GetExtension(editMovieModel.Video.FileName);
                    await editMovieModel.Video.AddVideoToServer(vidname, PathTools.MovieVideoServerPath, ExistMovie.VideoName);
                    ExistMovie.VideoName = vidname;
                }
                context.MovieModels.Update(ExistMovie);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return Json(" !--------- 😒 Errorr 😒 ---------! ");
        }
        #endregion

        #region Deleted
        // GET: MovieController/Delete/5
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var Movie = context.MovieModels.SingleOrDefault(x => x.MovieId == id);
            if (Movie == null) return NotFound();

            if (Movie.ImageName != null)
            {
                Tools.DeleteFile(PathTools.MovieImageServerPath, Movie.ImageName+".png");
                Tools.DeleteFile(PathTools.MovieImageServerPath, Movie.ImageName + ".jpg");
                Tools.DeleteFile(PathTools.MovieImageServerPath, Movie.ImageName + ".jfif");
            }
            if (Movie.VideoName != null)
            {
                Tools.DeleteFile(PathTools.MovieVideoServerPath, Movie.VideoName+".mp4");
            }

            context.MovieModels.Remove(Movie);
            context.SaveChanges();
            return Json(new { success = true });
        }

        #endregion


        #region AddOrSelectCast
        [HttpGet]
        public IActionResult AddCastToMovie(int id)
        {
            var movie = context.MovieModels.SingleOrDefault(x => x.MovieId == id);
            if (movie == null) return NotFound();
            ViewBag.MovieName = movie.MovieTitle;
            ViewBag.MovieId = id;
            ViewBag.Casts = new SelectList(context.CastModels, "CastId", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult AddCastToMovie(MovieMedCastViewModel vm)
        {
            if (vm == null) return NotFound();
            var movie = context.MovieModels.SingleOrDefault(m => m.MovieId == vm.MovieId);
            var cast = context.CastModels.SingleOrDefault(c => c.CastId == vm.CastId);
            if (ModelState.IsValid)
            {
                var newMed = new MovieMedCastModel()
                {
                    MovieId = vm.MovieId,
                    CastId = vm.CastId
                };
                context.MovieMedCastModels.Add(newMed);
                context.SaveChanges();
                TempData["Relation"] = $"Add Cast: {cast?.Name} To Movie:{movie?.MovieTitle}";
                return RedirectToAction("Index", "Movie");
            }

            return View();
        }
        #endregion
    }
}
