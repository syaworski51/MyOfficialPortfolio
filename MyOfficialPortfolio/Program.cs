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

var aws = secrets.GetSection("AWS");
builder.Services.AddSingleton<S3Service>(serviceProvider => new S3Service(
    aws.GetValue<string>("AccessKey")!,
    aws.GetValue<string>("SecretKey")!,
    aws.GetValue<string>("Region")!
));
builder.Services.AddSingleton<SESService>(serviceProvider => new SESService(
    aws.GetValue<string>("AccessKey")!,
    aws.GetValue<string>("SecretKey")!,
    aws.GetValue<string>("Region")!
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
