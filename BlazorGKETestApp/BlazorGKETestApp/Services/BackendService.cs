namespace BlazorGKETestApp.Services;

public class BackendService(HttpClient backendClient) : IBackendService
{
    public async Task<string[]?> CallWeatherAsync(CancellationToken cancellationToken)
    {
        var weatherResponse = await backendClient.GetAsync("/api/", cancellationToken);

        weatherResponse.EnsureSuccessStatusCode();
        var weather = await weatherResponse.Content.ReadFromJsonAsync<string[]>(cancellationToken: cancellationToken);

        return weather;
    }
}
