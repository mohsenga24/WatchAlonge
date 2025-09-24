using Microsoft.EntityFrameworkCore;
using WatchAlonge.Data;

var builder = WebApplication.CreateBuilder(args);

// using our connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// adding the db context to the builder services. We are using SQL Server here.
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString)); 

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
// need to add app.MapControllers();to make API controllers work
app.MapControllers();
// 
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
