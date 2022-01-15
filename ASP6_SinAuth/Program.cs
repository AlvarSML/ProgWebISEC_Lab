using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ASP6_SinAuth.Data;
using ASP6_SinAuth.Areas.Identity.Data;
using System.Globalization;
using ASP6_SinAuth.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ctxDatosConnection");builder.Services.AddDbContext<ctxDatos>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
}).AddRoles<IdentityRole>().AddEntityFrameworkStores<ctxDatos>();
// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
   
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Identidades
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();



app.Run();
