using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.DataAccess.Contexts;
using WebApplicationMVC.DataAccess.Models;
using WebApplicationMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();

builder.Services.AddDbContextPool<WebApplicationMVCDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("MVCAppDb")));

builder.Services.AddMvc(b => b.EnableEndpointRouting = false);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler();
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.UseMvcWithDefaultRoute();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
