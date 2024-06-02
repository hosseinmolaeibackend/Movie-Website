using Microsoft.AspNetCore.Mvc;
using Movie_Website.AppContext;
using Movie_Website.Models;
using Movie_Website.Utilities.enctype;
using Movie_Website.ViewModel;

namespace Movie_Website.Controllers
{
    public class RegisterController(ApplicationContext _db) : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                var UserIsExited = _db.UserModels.Any(u => u.Email == userVM.Email);
                if (!UserIsExited)
                {
                    var EncodePass = PasswordCreator.HashGenerator(userVM.Password);

                    var newUser = new UserModel() 
                    {
                        Email = userVM.Email,
                        FullName = userVM.FullName,
                        Password = EncodePass,
                        Phone=userVM.Phone

                    };

                    _db.UserModels.Add(newUser);
                    await _db.SaveChangesAsync();
                    return RedirectToAction("Login","Register");
                }
            }
            return View();
        }
    }
}
