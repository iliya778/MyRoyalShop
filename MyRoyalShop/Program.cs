using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyRoyalShop.Core.Interfaces;
using MyRoyalShop.Core.Services;
using MyRoyalShop.DataLayer.Context;
using MyRoyalShop.DataLayer.Interfaces;
using MyRoyalShop.DataLayer.Repositories;
using Microsoft.Extensions.DependencyInjection;
using MyRoyalShop.Data;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MyRoyalShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyRoyalShopContext") ?? throw new InvalidOperationException("Connection string 'MyRoyalShopContext' not found.")));
//builder.Services.AddDbContext<MyRoyalShopDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MyRoyalShopContext") ?? throw new InvalidOperationException("Connection string 'MyRoyalShopContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserService,UserService>();

builder.Services.AddDbContext<MyRoyalShopDbContext>(options =>
{
    options.UseSqlServer("Data Source=.;Initial Catalog=MyRoyalShopDb;TrustServerCertificate=True;Integrated Security=True");
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

}).AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/LogOut";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(43200);

});

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

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
