using Microsoft.EntityFrameworkCore;
using CinemaOnline.Models;
using CinemaOnline.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDistributedMemoryCache()
    ;


builder.Services.AddDbContext<MovieRentalContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbconn")));

builder.Services.AddSession(options =>
{
    options.Cookie.Name = "Sesija";
    options.Cookie.HttpOnly = true;
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.IsEssential = true;
});

// SERVICES
builder.Services.AddScoped<IActorsService, ActorsService>();
builder.Services.AddScoped<ICharacterService, CharacterService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IKorisniciService, KorisniciService>();
builder.Services.AddScoped<IRatingService, RatingService>();

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
app.UseSession();



app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
