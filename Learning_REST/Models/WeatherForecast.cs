namespace Learning_REST.Models
// THIS A MODEL
// remember models represent stored data
{
    public class WeatherForecast
    {
        // these are each properties of the model, which serve as attributes
        // in a DB, each attribute would have its own col and the model would represent a single row
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public double PrecipitationAmount { get; set; }

        public string PrecipitationType { get; set; } = "None";

        public string? Summary { get; set; }
    }
}
