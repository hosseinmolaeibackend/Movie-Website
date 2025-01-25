using Movie_Website.Domain.Models.Model;

namespace Movie_Website.Application.Services.IServicesAdmin
{
	public interface ICastServiece
	{
		public List<CastModel> GetAllCast();
		public CastModel GetCastById(int id);

	}
}
