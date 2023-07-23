using System.Net;
using anketdeneme.Models;
using anketdeneme.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "anketCookie";
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.LoginPath = "/Login/";
        options.AccessDeniedPath = "/Error/";
    });
builder.Services.AddTransient<IValidator<Sorular>, SoruValidator>();
builder.Services.AddTransient<IValidator<Users>, UserValidator>();
string? connectionString = builder.Configuration.GetConnectionString("Local");
if (connectionString != null)
{
    builder.Services.AddDbContext<RepoDbContext>(options =>
        options.UseSqlServer(connectionString));
}
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseStatusCodePagesWithRedirects("/Error/");
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.MapDefaultControllerRoute();
app.UseRouting();
app.UseAuthorization();
app.Run();
