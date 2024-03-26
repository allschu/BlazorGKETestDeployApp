namespace BlazorGKETestApp.Services;

public interface IBackendService
{
    Task<string[]?> CallWeatherAsync(CancellationToken cancellationToken);
}