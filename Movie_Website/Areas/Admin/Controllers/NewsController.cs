using Microsoft.AspNetCore.Mvc;
using Movie_Website.AppContext;
using DataLayer.Models;
using Movie_Website.Utilities;
using Movie_Website.ViewModel;
using System.Security.Claims;
using WebApplication2.Utilities.ImageHelper;

namespace Movie_Website.Areas.Admin.Controllers
{
    public class NewsController : AdminBaseController
    {
        private readonly ApplicationContext _db;
        public NewsController(ApplicationContext context)
        {
            _db = context;
        }
        public IActionResult ShowNewsList()
        {
            TempData["News"] = "active";
            var News = _db.NewsModels.ToList();
            return View(News);
        }

        #region create News
        [HttpGet]
        public IActionResult CreateNews()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateNews(NewsViewModel viewModel)
        {
            if ((viewModel.Description != null) && (viewModel.Image != null) && (viewModel.Title != null))
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
            var News = _db.NewsModels.SingleOrDefault(i => i.Id == id);
            var userid=User.FindFirstValue(ClaimTypes.NameIdentifier);
            if(News == null) return NotFound();
            var Views = new NewsViewModel()
            {
                Description=News.Description,
                UserId=Convert.ToInt32(userid), 
                Title=News.Title
            };
            return View(Views);
        }

        [HttpPost]
        public async Task<IActionResult> EditNews(int id,NewsViewModel viewModel)
        {
            if ((viewModel.Description != null) &&  (viewModel.Title != null))
            {
                var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var NewsArticle=_db.NewsModels.SingleOrDefault(i => i.Id == id);
                if (NewsArticle == null) return NotFound();
                NewsArticle.Title=viewModel.Title;
                NewsArticle.Description=viewModel.Description;
                NewsArticle.CreateTime = DateTime.Now;
                NewsArticle.UserId=Convert.ToInt32(userid);
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
            var NewsArticle=_db.NewsModels.Single(i => i.Id == id);
            if (NewsArticle == null) return NotFound();
            return View(NewsArticle);
        }
        #endregion
    }
}
