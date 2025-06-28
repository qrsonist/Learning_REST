using Learning_REST.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace Learning_REST.APIControllers
{
    [ApiController]
    // can be accessed by going to site URL /NAME_OF_CONTROLLER
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        // static indicates that upon reinstantiation of the object, the variable will not be reinitialized
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
                int RandomTemperatureC = Random.Shared.Next(-5, 45);
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

                double ProjectedPrecipitationAmount = 0;
                string ProjectedPrecipicationType = "None";
                // 33% chance of precipitation on any given day
                if (Random.Shared.GetItems([false, true, false], 1)[0])
                {
                    ProjectedPrecipitationAmount = Math.Floor((Math.Sqrt(Random.Shared.NextDouble() * 36)) * 100)/100;
                    ProjectedPrecipicationType = RandomTemperatureC <= 0 ? "Snow/Ice" : "Rain";
                }

                // adding rather than appending becuase appending does not modify the list in-place and instead returns a new iterable with the item appended
                forecasts.Add(new WeatherForecast()
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = RandomTemperatureC,
                    PrecipitationAmount = ProjectedPrecipitationAmount,
                    PrecipitationType = ProjectedPrecipicationType,
                    Summary = WeatherSummary
                });
            }
            return forecasts;
        }
    }
}
