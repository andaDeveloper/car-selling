using Microsoft.EntityFrameworkCore;
using sql_oriented_app.Controllers;
using sql_oriented_app.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//config database string connection
builder.Services.AddDbContext<ConcesionarioDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration["Cars_StringConnection"])
    );

//config sessions
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
}
    );

//config secrets
builder.Configuration.AddEnvironmentVariables();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    builder.Configuration.AddUserSecrets<HomeController>();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
