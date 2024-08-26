using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);
var sqlConnectionBuilder = new SqlConnectionStringBuilder();
if (builder.Environment.IsDevelopment()) {
    sqlConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("ServiceDesk_Connection_Dev");
} else {
    sqlConnectionBuilder.ConnectionString = builder.Configuration.GetConnectionString("ServiceDesk_Connection_Prod");
}

// Add services to the container.

builder.Services.AddDbContext<ServiceDeskContext>(options => options.UseSqlServer(sqlConnectionBuilder.ConnectionString));
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
    pattern: "{controller=Ticket}/{action=Index}/{id?}");

app.Run();
