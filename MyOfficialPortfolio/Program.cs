using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyOfficialPortfolio.Data;
using MyOfficialPortfolio.Models;
using MyOfficialPortfolio.Services;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var secrets = builder.Configuration.GetSection("Secrets");

// Add services to the container.
var connectionString = secrets.GetValue<string>("ConnectionStrings:DefaultConnection") ?? 
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<MongoDbContext>();

var s3Secrets = secrets.GetSection("AWS:S3");
builder.Services.AddSingleton<S3Service>(sp => new S3Service(
    s3Secrets["AccessKey"]!,
    s3Secrets["SecretKey"]!,
    s3Secrets["Region"]!
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
