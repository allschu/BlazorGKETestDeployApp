using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IBackendService
    {
        Task<WeatherForecast[]> GetWeatherAsync(CancellationToken cancellationToken = default);
    }
}
