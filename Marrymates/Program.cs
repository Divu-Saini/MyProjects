
using MarryMatesDotNet.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add session services
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; 
});


builder.Services.AddScoped<IVendorServiceRepository>(
    provider => new VendorServiceRepository(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IVenueRepository>(
    provider => new VenueRepository(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IEventRepository>(
    provider => new EventRepository(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IUserRepository>(
    provider => new UserRepository(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 

app.UseRouting();

app.UseSession(); 

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Login}/{id?}")
    .WithStaticAssets();

app.Run();
