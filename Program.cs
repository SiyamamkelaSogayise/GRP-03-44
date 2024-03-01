using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GeeksProject02.Data;
using GeeksProject02.Areas.Identity.Data;
using Microsoft.Extensions.Configuration; // Added this using directive
using GeeksProject02.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using OfficeOpenXml;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("GeeksProject02ContextConnection") ?? throw new InvalidOperationException("Connection string 'GeeksProject02ContextConnection' not found.");

builder.Services.AddDbContext<GeeksProject02Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<GeeksProject02User>().AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<GeeksProject02Context>();

builder.Services.AddAuthentication().AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
});

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<GeeksProject02Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GeeksProject02ContextConnection")));

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("patient", policy =>
        policy.RequireRole("patient"));

    options.AddPolicy("admin", policy =>
        policy.RequireRole("admin"));

    options.AddPolicy("doctor", policy =>
        policy.RequireRole("doctor"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
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

app.MapRazorPages();

app.Run();
