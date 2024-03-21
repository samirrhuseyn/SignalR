using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using SignalR.DataAccessLayer.Concrete;
using SignalR.EntityLayer.Entities;

var builder = WebApplication.CreateBuilder(args);

var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();

builder.Services.AddDbContext<SignalRContext>();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews(opt=>
{
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
});
builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<SignalRContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/Login/Index/";
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseStaticFiles();
app.UseDefaultFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
