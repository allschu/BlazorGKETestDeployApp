using BlazorGKETestApp.Client.Models;
using System.Net.Http.Json;

namespace BlazorGKETestApp.Client.Services
{
    public class ApiBackendService(HttpClient httpClient) : IApiBackend
    {
        public async Task<WeatherForecast[]?> CallWeatherAsync(CancellationToken cancellationToken = default)
        {
            return await httpClient.GetFromJsonAsync<WeatherForecast[]>("/weatherforecast", cancellationToken: cancellationToken);
        }
    }
}
