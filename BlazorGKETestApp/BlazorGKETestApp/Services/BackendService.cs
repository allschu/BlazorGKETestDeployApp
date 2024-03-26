namespace BlazorGKETestApp.Services;

public class BackendService : IBackendService
{
    private readonly HttpClient _backendClient;
    private readonly ILogger<BackendService> _logger;

    public BackendService(HttpClient backendClient, ILogger<BackendService> logger, IConfiguration configuration)
    {
        _backendClient = backendClient;
        _logger = logger;

        _backendClient.DefaultRequestHeaders.Add("X-Api-Key", configuration["ApiKey"]);
    }
    
    public async Task<string[]?> CallWeatherAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Calling weather endpoint: {_backendClient.BaseAddress}weatherforecast");

        var weatherResponse = await _backendClient.GetAsync("weatherforecast", cancellationToken);

        weatherResponse.EnsureSuccessStatusCode();
        var weather = await weatherResponse.Content.ReadFromJsonAsync<string[]>(cancellationToken: cancellationToken);

        return weather;
    }
}
