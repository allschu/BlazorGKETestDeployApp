
using System.Net.Http.Json;

namespace BlazorGKETestApp.Client;

public class ApiBackend(HttpClient httpClient) : IApiBackend
{
    public async Task<string[]?> CallWeatherAsync(CancellationToken cancellationToken)
    {
        var response = await httpClient.GetAsync("weatherforecast", cancellationToken);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<string[]>(cancellationToken);
    }
}
