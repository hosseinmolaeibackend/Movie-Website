using Movie_Website.Domain.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Website.Application.Services.IServices
{
	public interface INewsService
	{
		public Task<List<NewsModel>> GetAllNews();
		public NewsModel GetNewsById(int id);

	}
}
