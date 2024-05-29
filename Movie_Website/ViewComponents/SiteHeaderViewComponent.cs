using Microsoft.AspNetCore.Mvc;

namespace Movie_Website.ViewComponents
{
	public class SiteHeaderViewComponent : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("SiteHeader");
		}
	}
}
