using FeratureFlagsAPI.Services.Interfaces;

namespace FeratureFlagsAPI.Services
{
    public class FeatureTestService : IFeatureTestService
    {
        public IEnumerable<WeatherForecast> GetWeatherForecast()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = $"Weather from new service #{index}"
            })
            .ToArray();
        }
    }
}
