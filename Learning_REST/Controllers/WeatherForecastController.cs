using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Learning_REST.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly int[] Thresholds = new[]
        {
            0, 5, 10, 15, 20, 25, 30, 35, 40, 45
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        // i know this isn't very efficient but i hated how the file just randomized both the temp and summary
        public IEnumerable<WeatherForecast> Get()
        {
            
            // making a list because arrays are used statically in most cases
            List<WeatherForecast> forecasts = new List<WeatherForecast>();
            for (int index = 0; index <= 4; index++)
            {
                int RandomTemperatureC = Random.Shared.Next(-20, 45);
                // "?" makes the variable nullable
                string? WeatherSummary = null;
                int ThresholdIndex = 0;
                // gimme a break i don't know the syntax for ennumerated loops yet
                foreach(int threshold in Thresholds)
                {
                    if (RandomTemperatureC <= threshold)
                    {
                        WeatherSummary = Summaries[ThresholdIndex];
                    }
                    else
                    {
                        ThresholdIndex++;
                    }

                }
                // adding rather than appending becuase appending does not modify the list in-place and instead returns a new iterable with the item appended
                forecasts.Add(new WeatherForecast()
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = RandomTemperatureC,
                    Summary = WeatherSummary
                });
            }
            return forecasts;
        }
    }
}
