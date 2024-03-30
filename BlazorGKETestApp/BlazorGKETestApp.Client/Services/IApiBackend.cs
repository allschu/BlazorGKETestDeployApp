using BlazorGKETestApp.Client.Models;

namespace BlazorGKETestApp.Client;

public interface IApiBackend
{
     Task<WeatherForecast[]?> CallWeatherAsync(CancellationToken cancellationToken = default);
}
