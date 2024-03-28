using System.Net;
using Dapr.Client;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class BackendService(IHttpClientFactory httpClientFactory) : IBackendService
    {
        public async Task<WeatherForecast[]> GetWeatherAsync(CancellationToken cancellationToken = default)
        {
            //var client = DaprClient.CreateInvokeHttpClient(appId: "api");
            using var client = httpClientFactory.CreateClient("BackendClient");
            var response = await client.GetAsync("/weatherforecast", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<WeatherForecast[]>(cancellationToken: cancellationToken);
                return result;
            }

            throw new Exception($"Error {response.StatusCode}");
        }
    }
}
