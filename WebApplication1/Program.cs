using WebApplication1.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddHttpClient("BackendClient", c =>
{
    c.BaseAddress = new Uri(builder.Configuration["BackendUrl"]!);
    c.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration["ApiKey"]);
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IBackendService, BackendService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
