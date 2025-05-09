using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Movie_Website.Application.Services.IServices;
using Movie_Website.Application.Services.IServicesAdmin;
using Movie_Website.Infrastructure.AppContext;
using Movie_Website.Infrastructure.Services.Service;
using Movie_Website.Infrastructure.Services.ServicesAdmin;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
	ContentRootPath = Directory.GetCurrentDirectory(),
	WebRootPath = "Presentation/wwwroot"
});

// Add services to the container.
//builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews()
	.AddRazorOptions(options =>
	{
		options.ViewLocationFormats.Add("/Presentation/Views/{1}/{0}.cshtml");
		options.ViewLocationFormats.Add("/Presentation/Views/Shared/{0}.cshtml");
		options.AreaViewLocationFormats.Add("/Presentation/Areas/{2}/Views/{1}/{0}.cshtml");
		options.AreaViewLocationFormats.Add("/Presentation/Areas/{2}/Views/Shared/{0}.cshtml");
	});



builder.Services.AddDbContext<ApplicationContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("defult"));
});

builder.Services.AddScoped<ICastServiece, CastService>();
builder.Services.AddScoped<IMovieService,MovieService>();
builder.Services.AddTransient<INewsService,NewsService>();

builder.Services.AddAuthentication(option =>
{
    option.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = "/login";
    option.LogoutPath = "/logout";
    option.ExpireTimeSpan = TimeSpan.FromDays(10);
    option.SlidingExpiration = true;

});

var app = builder.Build();

app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
	name: "areaRoute",
	pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}"
);


app.Run();
