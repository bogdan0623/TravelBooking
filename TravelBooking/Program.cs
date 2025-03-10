using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelBooking.Data;
using TravelBooking.Factories;
using TravelBooking.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Injectam repositories
builder.Services.AddTransient<StatusRepository>();
builder.Services.AddTransient<CountryRepository>();
builder.Services.AddTransient<CityRepository>();
builder.Services.AddTransient<DestinationRepository>();
builder.Services.AddTransient<BookingRepository>();
builder.Services.AddTransient<ImageRepository>();
builder.Services.AddTransient<CustomerRepository>();
builder.Services.AddTransient<CustomerViewModelFactory>();
builder.Services.AddTransient<DestinationViewModelFactory>();
builder.Services.AddTransient<LocationViewModelFactory>();
builder.Services.AddTransient<BookingViewModelFactory>();

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
