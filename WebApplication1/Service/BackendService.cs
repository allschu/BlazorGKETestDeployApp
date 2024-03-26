using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class BackendService(IHttpClientFactory httpClientFactory) : IBackendService
    {
        public async Task<WeatherForecast[]> GetWeatherAsync(CancellationToken cancellationToken = default)
        {
            using var client = httpClientFactory.CreateClient("BackendClient");
            var response = await client.GetAsync("/weatherforecast", cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<WeatherForecast[]>(cancellationToken: cancellationToken);

            if (result == null)
                throw new InvalidOperationException("WeatherForecast failed");

            return result;
        }
    }
}
