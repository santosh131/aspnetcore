var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var app = builder.Build();


app.Logger.LogInformation($"log information: areas");

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

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "Areas",
//        pattern: "{areas:exists}/{controller=Home}/{action=Index}");
//});

app.UseEndpoints(endpoints =>
{
    app.MapAreaControllerRoute(
            name: "Products",
            areaName: "Products",
            pattern: "Products/{controller=Home}/{action=Index}");
});

app.UseEndpoints(endpoints =>
{
    app.MapAreaControllerRoute(
            name: "EmployeeAreas",
            areaName: "Employees",
            pattern: "Employees/{controller=Home}/{action=Index}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
