using Microsoft.AspNetCore.Authentication.Cookies;
using WebApp.Models;
using WebApp.Services;
using WebApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient<IIdentityService, IdentityService>();
builder.Services.Configure<ServiceApiSettings>(builder.Configuration.GetSection("ServiceApiSettings"));
builder.Services.Configure<ClientSettings>(builder.Configuration.GetSection("ClientSettings"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
{
    opt.LoginPath = "/Auth/SignIn";
    opt.ExpireTimeSpan = TimeSpan.FromDays(60);
    opt.SlidingExpiration = true;
    opt.Cookie.Name = "udemywebcookie";
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
