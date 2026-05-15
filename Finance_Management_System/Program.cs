

using Finance_Management_System.Helpers;
using Finance_Management_System.Models.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddScoped<AuthenticationHelpers>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddDbContext<FinanceDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("dbConnectionString")));
var app = builder.Build();
    
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
