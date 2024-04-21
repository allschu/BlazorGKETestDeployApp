using Dapr.Client;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class BackendService(IConfiguration _configuration) : IBackendService
    {
        public async Task<WeatherForecast[]> GetWeatherAsync(CancellationToken cancellationToken = default)
        {
            //var client = DaprClient.CreateInvokeHttpClient(appId: "api");
            using var client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["ApiUrl"]);
            client.DefaultRequestHeaders.Add("X-API-KEY", _configuration["ApiKey"]);
            var response = await client.GetAsync("/weatherforecast", cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<WeatherForecast[]>(cancellationToken: cancellationToken);
            }

            throw new Exception($"Error {response.StatusCode}");
        }
    }
}