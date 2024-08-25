using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;

var builder = WebApplication.CreateBuilder(args);
var sqlconnbuilder = new SqlConnectionStringBuilder
{
    ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection"),
    UserID = "sa",
    Password = "resume@6270",
    InitialCatalog = "TicketDB",
    Encrypt = true,
    TrustServerCertificate = true
};
// Add services to the container.

builder.Services.AddDbContext<ServiceDeskContext>(options => options.UseSqlServer(sqlconnbuilder.ConnectionString));
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
