using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Repositories;
using MeteoApplicationMVC.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using MeteoApplicationMVC.Services;
using Microsoft.AspNetCore.Identity;
using MeteoApplicationMVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();



builder.Services.Add(new ServiceDescriptor(typeof(ILog), new ConsoleLogger()));

builder.Services.AddScoped<IRepositoryAlert, RepositoryAlert>();
builder.Services.AddScoped<IServiceAlert, ServiceAlert>();

builder.Services.AddScoped<IRepositoryCity, RepositoryCity>();
builder.Services.AddScoped<IServiceCity, ServiceCity>();

builder.Services.AddScoped<IRepositoryContact, RepositoryContact>();
builder.Services.AddScoped<IServiceContact, ServiceContact>();

builder.Services.AddScoped<IRepositoryFavoriteLocation, RepositoryFavoriteLocation>();
builder.Services.AddScoped<IServiceFavoriteLocation, ServiceFavoriteLocation>();

builder.Services.AddScoped<IRepositoryMeteorologist, RepositoryMeteorologist>();
builder.Services.AddScoped<IServiceMeteorologist, ServiceMeteorologist>();

builder.Services.AddScoped<IRepositoryNews, RepositoryNews>();
builder.Services.AddScoped<IServiceNews, ServiceNews>();

builder.Services.AddScoped<IRepositoryStation, RepositoryStation>();
builder.Services.AddScoped<IServiceStation, ServiceStation>();

builder.Services.AddScoped<IRepositoryUser, RepositoryUser>();
builder.Services.AddScoped<IServiceUser, ServiceUser>();

builder.Services.AddScoped<IRepositoryWeatherData, RepositoryWeatherData>();
builder.Services.AddScoped<IServiceWeatherData, ServiceWeatherData>();

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();


//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDb")));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApplicationDb")));

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 4;

    // Lockout settings
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User Settings
    options.User.RequireUniqueEmail = true;
    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";

});



builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["App:GoogleClientId"];
        options.ClientSecret = builder.Configuration["App:GoogleClientSecret"];
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

app.MapRazorPages();

app.Run();
