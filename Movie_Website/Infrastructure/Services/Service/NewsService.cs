using Microsoft.EntityFrameworkCore;
using Movie_Website.Application.Services.IServices;
using Movie_Website.Domain.Models.Model;
using Movie_Website.Infrastructure.AppContext;
using Movie_Website.Infrastructure.Services.Utilities.Tools;
using Movie_Website.Infrastructure.Services.Utilities;

namespace Movie_Website.Infrastructure.Services.Service
{
	public class NewsService : INewsService
	{
		private readonly ApplicationContext _db;
		public NewsService(ApplicationContext context)
		{
			_db = context;
		}
		public async Task<List<NewsModel>> GetAllNews()
		{
			return await _db.NewsModels.OrderByDescending(x=>x.CreateTime).ToListAsync();
		}

		public NewsModel GetNewsById(int id)
		{
			var news =
				_db.NewsModels.SingleOrDefault(x => x.Id == id);
			if (news == null) throw new ArgumentNullException(nameof(news));
			return news;
		}

		public bool DeletedNews(int id)
		{
			var news = _db.NewsModels.SingleOrDefault(x => x.Id == id);
			if (news == null) return false;

			if (news.ImageNews != null)
			{
				Tools.DeleteFile(PathTools.NewsImageServerPath, news.ImageNews + ".png");
				Tools.DeleteFile(PathTools.NewsImageServerPath, news.ImageNews + ".jpg");
				Tools.DeleteFile(PathTools.NewsImageServerPath, news.ImageNews + ".jfif");
			}
			

			_db.NewsModels.Remove(news);
			_db.SaveChanges();
			return true;
		}
	}
}
