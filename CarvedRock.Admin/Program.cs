using CarvedRock.Admin.Contexts;
using CarvedRock.Admin.Interfaces.Managers;
using CarvedRock.Admin.Interfaces.Repositories;
using CarvedRock.Admin.Managers;
using CarvedRock.Admin.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProductContext>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<ICarvedRockRepository, CarvedRockRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var cxt = services.GetRequiredService<ProductContext>();

    cxt.Database.Migrate();

    if (app.Environment.IsDevelopment())
    {
        cxt.SeedInitialData();
    }
}

app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
