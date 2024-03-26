using BlazorGKETestApp.Client;
using BlazorGKETestApp.Client.Services;
using BlazorGKETestApp.Components;
using BlazorGKETestApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseSetting(WebHostDefaults.DetailedErrorsKey, "true");

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["BackendUrl"]!)
});

builder.Services.AddScoped<IBackendService, BackendService>();
builder.Services.AddScoped<IApiBackend, ApiBackendService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorGKETestApp.Client._Imports).Assembly);

app.Run();
