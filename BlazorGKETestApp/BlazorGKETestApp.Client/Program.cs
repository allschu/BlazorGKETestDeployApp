using BlazorGKETestApp.Client;
using BlazorGKETestApp.Client.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

var httpclient = new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};
httpclient.BaseAddress = new Uri(builder.Configuration["BackendUrl"]!);
httpclient.DefaultRequestHeaders.Add("X-Api-Key", builder.Configuration["ApiKey"]);

builder.Services.AddSingleton(httpclient);

// Register the client-side weather service
builder.Services.AddSingleton<IApiBackend, ApiBackendService>();


await builder.Build().RunAsync();
