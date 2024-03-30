using Dapr.Client;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class BackendService() : IBackendService
    {
        public async Task<WeatherForecast[]> GetWeatherAsync(CancellationToken cancellationToken = default)
        {
            var client = DaprClient.CreateInvokeHttpClient(appId: "api");

            var response = await client.GetAsync("/weatherforecast", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WeatherForecast[]>(cancellationToken: cancellationToken);
            }

            throw new Exception($"Error {response.StatusCode}");
        }
    }
}