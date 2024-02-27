var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMvc();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();


var app = builder.Build();
app.Logger.LogInformation("Log information - routing");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

//EndPoints
app.MapGet("/Hello", () => "Hello world");
app.MapGet("/Hello2", (HttpContext context) =>
{
    return $"Hello 2 {context.GetEndpoint()?.DisplayName}";
});

app.MapGet("/Hello3async", async (HttpContext context) =>
{
   await context.Response.WriteAsync($"Hello3 async{context.GetEndpoint()?.DisplayName}");
});

app.UseEndpoints(_ => { });
app.MapControllers();

//Convention based routing
app.MapControllerRoute(name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
