using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Movie_Website.Infrastructure.AppContext;
using Movie_Website.Presentation.ViewModels;
using Movie_Website.Domain.Models.Model;
using Movie_Website.Infrastructure.Services.Utilities.enctype;

namespace Movie_Website.Presentation.Controllers
{
	public class RegisterController(ApplicationContext _db) : Controller
	{
		#region login
		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}
		[HttpPost, ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginViewModel loginVM)
		{
			if (ModelState.IsValid)
			{
				var user = _db.UserModels.SingleOrDefault(u => u.Email == loginVM.Email);
				if (user == null) return View();
				if (user.Password != PasswordCreator.HashGenerator(loginVM.Password)) return View();
				List<Claim> claims = new List<Claim>()
				{
					new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
					new Claim(ClaimTypes.Email,loginVM.Email)
				};
				ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
				ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
				AuthenticationProperties authenticationProperties = new AuthenticationProperties()
				{
					IsPersistent = loginVM.RememberMe
				};
				await HttpContext.SignInAsync(claimsPrincipal, authenticationProperties);
				return RedirectToAction("Index", "Home");
			}
			return View();
		}

		#endregion

		#region Register
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
						Phone = userVM.Phone

					};

					_db.UserModels.Add(newUser);
					await _db.SaveChangesAsync();
					return RedirectToAction("Login", "Register");
				}
			}
			return View();
		}
		#endregion

		#region Logout
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return RedirectToAction("Index", "Home");
		}
		#endregion
	}
}
