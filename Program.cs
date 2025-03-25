using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShopingList.Data; // Ensure this is the correct namespace where your DbContext is

var builder = WebApplication.CreateBuilder(args);

// Get Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

// Register LibraryDbContext (For Library Data - Books, Users, etc.)
builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add Identity Services
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false) // Set to false for easy development
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Ensure Authentication Middleware is used
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages(); // Needed for Identity

app.Run();
