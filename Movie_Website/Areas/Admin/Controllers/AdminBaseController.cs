using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Movie_Website.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class AdminBaseController : Controller
	{
	
	}
}
