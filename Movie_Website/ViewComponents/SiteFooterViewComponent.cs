using Microsoft.AspNetCore.Mvc;

namespace Movie_Website.ViewComponents
{
	public class SiteFooterViewComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("SiteFooter");
		}
	}
}
