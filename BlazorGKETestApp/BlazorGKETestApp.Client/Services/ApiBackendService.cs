using BlazorGKETestApp.Client.Models;
using System.Net.Http.Json;

namespace BlazorGKETestApp.Client.Services
{
    public class ApiBackendService(HttpClient httpClient, ILogger<ApiBackendService> logger) : IApiBackend
    {
        public async Task<WeatherForecast[]?> CallWeatherAsync(CancellationToken cancellationToken = default)
        {
            logger.LogInformation($"Calling Http {httpClient.BaseAddress}/weatherforecast");
            return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast", cancellationToken: cancellationToken);
        }
    }
}
