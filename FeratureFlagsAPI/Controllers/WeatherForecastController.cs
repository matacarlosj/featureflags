using FeratureFlagsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace FeratureFlagsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IFeatureManager _featureManager;

        private readonly IFeatureTestService _featureTestService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IFeatureManager featureManager, IFeatureTestService featureTestService)
        {
            _logger = logger;
            _featureManager = featureManager;
            _featureTestService = featureTestService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            var useNewService = await _featureManager.IsEnabledAsync(FeatureFlags.UseNewService);

            if (useNewService)
                return _featureTestService.GetWeatherForecast();
            
            else
            {
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
            }

        }
    }
}