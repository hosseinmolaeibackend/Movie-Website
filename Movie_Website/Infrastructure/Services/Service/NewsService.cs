using Microsoft.EntityFrameworkCore;
using Movie_Website.Application.Services.IServices;
using Movie_Website.Domain.Models.Model;
using Movie_Website.Infrastructure.AppContext;

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
			return await _db.NewsModels.ToListAsync();
		}

		public NewsModel GetNewsById(int id)
		{
			var news =
				_db.NewsModels.SingleOrDefault(x => x.Id == id);
			if (news == null) throw new ArgumentNullException(nameof(news));
			return news;
		}
	}
}
