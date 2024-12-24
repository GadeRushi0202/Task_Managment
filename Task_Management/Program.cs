using Microsoft.EntityFrameworkCore;
using Task_Management.Data;
using Task_Management.Repositry;
using Task_Management.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var ConnectionStrings = builder.Configuration.GetConnectionString("defaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(ConnectionStrings));

builder.Services.AddScoped<ITaskManagementRepo, TaskManagementRepo>();
builder.Services.AddScoped<ITaskManagementServices, TaskManagementServices>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
