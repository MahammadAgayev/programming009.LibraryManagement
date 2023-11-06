using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

using programming009.LibraryManagement.Core.DataAccessLayer.SqlServer;
using programming009.LibraryManagement.Core.Domain.Entities;
using programming009.LibraryManagement.Core.Domain.Repositories;
using programming009.LibraryManagementWeb.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddScoped<IUnitOfWork>(x => new SqlUnitOfWork(connectionString)); ;
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();

builder.Services.AddIdentity<User, Role>();
builder.Services.AddTransient<IUserStore<User>, UserStore>();
builder.Services.AddTransient<IRoleStore<Role>, RoleStore>();

builder.Services.AddControllersWithViews();

builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequiredLength = 6;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.Password.RequireDigit = false;
    x.Password.RequireLowercase = false;
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
