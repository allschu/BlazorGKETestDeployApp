using Dapr.Client;
using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();


builder.Services.AddHttpClient("BackendClient", c =>
{
    c.BaseAddress = new Uri("http://localhost:3500");
    //c.BaseAddress = new Uri(builder.Configuration["BackendUrl"]!);
    //  c.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration["ApiKey"]);
    c.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    c.DefaultRequestHeaders.Add("dapr-app-id", "api");

});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IBackendService, BackendService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseExceptionHandler("/Home/Error");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
