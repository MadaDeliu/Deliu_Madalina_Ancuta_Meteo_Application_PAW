namespace MeteoApplicationMVC.Models
{
    public class WeatherData
    {
        public int Id { get; set; }
        public int? StationId { get; set; }
        public DateTime? Datetime { get; set; }
        public double? Temperature { get; set; }
        public double? WindSpeed { get; set; }
        public double? Precipitation { get; set; }
        public int? Humidity { get; set; }

        public Station? Station { get; set; }
    }
}
