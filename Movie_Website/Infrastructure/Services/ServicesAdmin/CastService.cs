using Movie_Website.Application.Services.IServicesAdmin;
using Movie_Website.Domain.Models.Model;
using Movie_Website.Infrastructure.AppContext;

namespace Movie_Website.Infrastructure.Services.ServicesAdmin
{
	public class CastService : ICastServiece
	{
		private readonly ApplicationContext _db;
		public CastService(ApplicationContext context)
		{
			_db = context;
		}

		public List<CastModel> GetAllCast()
		{
			return _db.CastModels.ToList();
		}

		public CastModel GetCastById(int id)
		{
			var cast = _db.CastModels.SingleOrDefault(x => x.CastId == id);
			if (cast == null) throw new ArgumentNullException(nameof(cast));
			return cast;
		}
	}
}
