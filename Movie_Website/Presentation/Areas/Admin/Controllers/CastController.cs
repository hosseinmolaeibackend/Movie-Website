using Microsoft.AspNetCore.Mvc;
using Movie_Website.Infrastructure.AppContext;
using Movie_Website.Presentation.ViewModels;
using Movie_Website.Domain.Models.Model;
using Movie_Website.Application.Services.IServicesAdmin;
using Movie_Website.Infrastructure.Services.Utilities;
using Movie_Website.Infrastructure.Services.Utilities.ImageHelper;
using Movie_Website.Infrastructure.Services.Utilities.Tools;

namespace Movie_Website.Presentation.Areas.Admin.Controllers
{
	public class CastController : AdminBaseController
	{
		#region Dependencies
		private readonly ApplicationContext _db;
		private readonly ICastServiece _castServiece;
		public CastController(ApplicationContext context, ICastServiece castServiece)
		{
			_db = context;
			_castServiece = castServiece;
		}
		#endregion

		#region Show Cast To Admin
		public IActionResult ShowCast()
		{
			TempData["Cast"] = "active";
			return View(_castServiece.GetAllCast());
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
				if (castVM.Image != null)
				{
					var Imgname = Guid.NewGuid().ToString("N") + Path.GetExtension(castVM.Image.FileName);
					castVM.Image.AddImageToServer(Imgname, PathTools.CastImageServerPath,
						524, 721, PathTools.CastImageThumbServerPath);
					newCast.ImageName = Imgname;
				}
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
			var cast = _castServiece.GetCastById(id);
			if (cast == null) return NotFound();
			var vm = new CastViewModel()
			{
				Name = cast.Name,
				Bio = cast.Bio,
				Age = cast.Age,
				ImageName = cast.ImageName
			};
			return View(vm);
		}
		[HttpPost]
		public IActionResult EditCast(int id, CastViewModel castVM)
		{
			var cast = _db.CastModels.SingleOrDefault(c => c.CastId == id);
			if (cast == null) return NotFound();
			if (ModelState.IsValid)
			{
				cast.Name = castVM.Name;
				cast.Bio = castVM.Bio;
				cast.Age = castVM.Age;
				if (castVM.Image != null)
				{
					var Imgname = Guid.NewGuid().ToString("N") + Path.GetExtension(castVM.Image.FileName);
					castVM.Image.AddImageToServer(Imgname, PathTools.CastImageServerPath,
						524, 721, PathTools.CastImageThumbServerPath, cast.ImageName);
					cast.ImageName = Imgname;
				}


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
			var CastOverView = _castServiece.GetCastById(id);
			if (CastOverView == null) return NotFound();
			return View(CastOverView);
		}
		#endregion

		#region Delete Cast
		[HttpDelete]
		public IActionResult DeleteCast(int id)
		{
			var cast = _castServiece.GetCastById(id);
			if (cast == null) return NotFound();
			if (cast.ImageName != null)
			{
				Tools.DeleteFile(PathTools.CastImageServerPath, cast.ImageName + ".png");
				Tools.DeleteFile(PathTools.CastImageServerPath, cast.ImageName + ".jpg");
				Tools.DeleteFile(PathTools.CastImageServerPath, cast.ImageName + ".jfif");

				Tools.DeleteFile(PathTools.CastImageThumbServerPath, cast.ImageName + ".png");
				Tools.DeleteFile(PathTools.CastImageThumbServerPath, cast.ImageName + ".jpg");
				Tools.DeleteFile(PathTools.CastImageThumbServerPath, cast.ImageName + ".jfif");
			}

			_db.CastModels.Remove(cast);
			_db.SaveChanges();
			return Json(new { success = true });
		}

		#endregion
	}
}
