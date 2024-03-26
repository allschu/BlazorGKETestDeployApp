namespace BlazorGKETestApp.Client;

public interface IApiBackend
{
     Task<string[]?> CallWeatherAsync(CancellationToken cancellationToken);
}
