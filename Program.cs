using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GeeksProject02.Data;
using GeeksProject02.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("GeeksProject02ContextConnection") ?? throw new InvalidOperationException("Connection string 'GeeksProject02ContextConnection' not found.");

builder.Services.AddDbContext<GeeksProject02Context>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<GeeksProject02User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<GeeksProject02Context>();

builder.Services.AddAuthentication().AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<GeeksProject02Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GeeksProject02ContextConnection")));


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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
