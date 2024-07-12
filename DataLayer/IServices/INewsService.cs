using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IServices
{
	public interface INewsService
	{
		public Task<List<NewsModel>> GetAllNews();
		public  NewsModel GetNewsById(int id);

	}
}
