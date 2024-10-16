using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using UniversityFront.Data;
using DAOControllers.ManagerControllers;
using DAOControllers;
using Models;

var builder = WebApplication.CreateBuilder(args);

var universityConnection = builder.Configuration.GetConnectionString("universityConnection");

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("universityConnection")));

builder.Services.AddScoped<IGenericRepository<Student>, DAOStudent>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
