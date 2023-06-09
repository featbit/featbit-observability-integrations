using Microsoft.AspNetCore.Mvc;
using FeatBit.Sdk.Server;
using FeatBit.Sdk.Server.Model;
using OpenTelemetry.Trace;

namespace OpenTelemetryApm.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IOtelFeatBitClient _client;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOtelFeatBitClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInformation("WeatherForecastController:Get");

            var user = FbUser.Builder("user-key-00000000000001").Name("user-00000000000001").Build();
            var variation = _client.BoolVariation(user, "feature-a");
            if (variation == true)
                throw new Exception("An error has detected when running new feature a");
            else
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}