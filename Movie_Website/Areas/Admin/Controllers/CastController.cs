using Microsoft.AspNetCore.Mvc;
using Movie_Website.AppContext;
using Movie_Website.Models;
using Movie_Website.ViewModel;

namespace Movie_Website.Areas.Admin.Controllers
{
    public class CastController : AdminBaseController
    {
        #region Dependencies
        private readonly ApplicationContext _db;
        public CastController(ApplicationContext context)
        {
            _db = context;
        }
        #endregion

        #region Show Cast To Admin
        public IActionResult ShowCast()
        {
            TempData["Cast"] = "active";
            return View(_db.CastModels.ToList());
        }
        #endregion

        #region CreateCast
        [HttpGet]
        public IActionResult CreateCast()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateCast(CastViewModel castVM)
        {
            if (ModelState.IsValid)
            {
                var newCast = new CastModel()
                {
                    Name = castVM.Name,
                    Bio = castVM.Bio,
                    Age = castVM.Age
                };
                _db.CastModels.Add(newCast);
                _db.SaveChanges();
                return RedirectToAction("ShowCast");
            }
            return View();
        }
        #endregion

        #region Edit Cast
        [HttpGet]
        public IActionResult EditCast(int id)
        {
            var cast = _db.CastModels.SingleOrDefault(c => c.CastId == id);
            if (cast == null) return NotFound();
            var vm = new CastViewModel()
            {
                Name = cast.Name,
                Bio = cast.Bio,
                Age = cast.Age
            };
            return View(vm);
        }
        [HttpPost]
        public IActionResult EditCast(int id, CastViewModel castVM)
        {
            var cast = _db.CastModels.SingleOrDefault(c => c.CastId == id);
            if (ModelState.IsValid)
            {
                cast.Name = castVM.Name;
                cast.Bio = castVM.Bio;
                cast.Age = castVM.Age;
                _db.CastModels.Update(cast);
                _db.SaveChanges();
                return RedirectToAction("ShowCast");
            }
            return View();
        }
        #endregion

        #region Details
        public IActionResult DetailCast(int id) 
        {
            var CastOverView=_db.CastModels.SingleOrDefault(x=>x.CastId == id);
            if (CastOverView == null) return NotFound();
            return View(CastOverView);
        }
        #endregion
    }
}
