using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AspRazorPage.Data;
var builder = WebApplication.CreateBuilder(args);

/*
 * first create Model class
 * second create folder Verduras inside Pages folder 
 * next add razor pages crud
 * go nugget console
 * Add-Migration InitialCreate
 * Update-DataBase
 */

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AspRazorPageContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AspRazorPageContext")));

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
