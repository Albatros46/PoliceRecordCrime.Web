using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PoliceRecordCrime.Models;
using PoliceRecordCrime.Repository;
using PoliceRecordCrime.Repository.Implementation;
using PoliceRecordCrime.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PoliceRecordCrimeWebContextConnection") ?? throw new InvalidOperationException("Connection string 'PoliceRecordCrimeWebContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();

//Repository icinde interface ler yazildiktan sonra burada tanimlama yapilacak
builder.Services.AddScoped<IPoliceStationRepo, PoliceStationRepo>();



// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
