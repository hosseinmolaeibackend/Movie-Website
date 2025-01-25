using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Movie_Website.Infrastructure.AppContext;
using Movie_Website.Presentation.ViewModels;
using Movie_Website.Domain.Models.Model;
using Movie_Website.Application.Services.IServices;
using Movie_Website.Infrastructure.Services.Utilities;
using Movie_Website.Infrastructure.Services.Utilities.ImageHelper;

namespace Movie_Website.Presentation.Areas.Admin.Controllers
{
	public class NewsController : AdminBaseController
	{
		#region DependencyInjection
		private readonly ApplicationContext _db;
		private readonly INewsService _newsService;
		public NewsController(ApplicationContext context, INewsService newsService)
		{
			_db = context;
			_newsService = newsService;
		}
		#endregion

		#region Show News async
		public async Task<IActionResult> ShowNewsList()
		{
			TempData["News"] = "active";
			
			return View(await _newsService.GetAllNews());
		}
		#endregion

		#region create News
		[HttpGet]
		public IActionResult CreateNews()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateNews(NewsViewModel viewModel)
		{
			if (viewModel.Description != null && viewModel.Image != null && viewModel.Title != null)
			{
				var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var news = new NewsModel()
				{
					Title = viewModel.Title,
					Description = viewModel.Description,
					UserId = Convert.ToInt32(userid),
					CreateTime = DateTime.Now
				};
				var imgname = Guid.NewGuid().ToString("N") + Path.GetExtension(viewModel.Image.FileName);
				viewModel.Image.AddImageToServer(imgname, PathTools.NewsImageServerPath, 700, 300, PathTools.NewsImageThumbServerPath);
				news.ImageNews = imgname;
				_db.NewsModels.Add(news);
				await _db.SaveChangesAsync();
				return RedirectToAction("ShowNewsList");
			}
			return View();
		}
		#endregion

		#region edit News
		[HttpGet]
		public IActionResult EditNews(int id)
		{
			var News = _newsService.GetNewsById(id);
			var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
			if (News == null) return NotFound();
			var Views = new NewsViewModel()
			{
				Description = News.Description,
				UserId = Convert.ToInt32(userid),
				Title = News.Title
			};
			return View(Views);
		}

		[HttpPost]
		public async Task<IActionResult> EditNews(int id, NewsViewModel viewModel)
		{
			if (viewModel.Description != null && viewModel.Title != null)
			{
				var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
				var NewsArticle = _db.NewsModels.SingleOrDefault(i => i.Id == id);
				if (NewsArticle == null) return NotFound();
				NewsArticle.Title = viewModel.Title;
				NewsArticle.Description = viewModel.Description;
				NewsArticle.CreateTime = DateTime.Now;
				NewsArticle.UserId = Convert.ToInt32(userid);
				if (viewModel.Image != null)
				{
					var imgname = Guid.NewGuid().ToString("N") + Path.GetExtension(viewModel.Image.FileName);
					viewModel.Image.AddImageToServer(imgname, PathTools.NewsImageServerPath,
					   700, 300, PathTools.NewsImageThumbServerPath, NewsArticle.ImageNews);
					NewsArticle.ImageNews = imgname;
				}
				_db.NewsModels.Update(NewsArticle);
				await _db.SaveChangesAsync();
				return RedirectToAction("ShowNewsList");
			}
			return View();
		}
		#endregion

		#region deleted News
		public IActionResult DeleteNews(int id)
		{
			return Json(new
			{
				success = true
			});
		}
		#endregion

		#region detail News
		[HttpGet]
		public IActionResult DetailNews(int id)
		{
			var NewsArticle = _newsService.GetNewsById(id);
			if (NewsArticle == null) return NotFound();
			return View(NewsArticle);
		}
		#endregion
	}
}
