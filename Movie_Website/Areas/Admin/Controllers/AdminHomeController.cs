using Microsoft.AspNetCore.Mvc;
using Movie_Website.AppContext;

namespace Movie_Website.Areas.Admin.Controllers
{
    public class AdminHomeController(ApplicationContext context) : AdminBaseController
    {
        public IActionResult Index()
        {
            return View(context.UserModels.ToList());
        }

        public IActionResult CreateUser()
        {
            return View(context.UserModels.ToList());
        }

        public IActionResult UserInformation(int id)
        {
            return View(context.UserModels.ToList());
        }
    }
}
