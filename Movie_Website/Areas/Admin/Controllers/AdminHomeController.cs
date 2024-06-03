using Microsoft.AspNetCore.Mvc;
using Movie_Website.AppContext;

namespace Movie_Website.Areas.Admin.Controllers
{
    public class AdminHomeController(ApplicationContext context) : AdminBaseController
    {
        public IActionResult Index()
        {
            TempData["AdminHome"] = "active";
            return View(context.UserModels.ToList());
        }

        public IActionResult DeleteUser(int id)
        {
            var user = context.UserModels.SingleOrDefault(x => x.UserId == id);
            if (user == null) return NotFound();
            context.UserModels.Remove(user);
            context.SaveChanges();
            return Json(new { success = true });
        }

        public IActionResult UserInformation(int id)
        {
            var user=context.UserModels.SingleOrDefault(x=>x.UserId == id);
            return PartialView(user);
        }
    }
}
