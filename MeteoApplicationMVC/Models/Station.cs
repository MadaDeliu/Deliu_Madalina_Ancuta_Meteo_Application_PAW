namespace MeteoApplicationMVC.Models
{
    public class Station
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CityId { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        public City? City { get; set; }
        public ICollection<WeatherData>? WeatherData { get; set; }
        public ICollection<Meteorologist>? Meteorologists { get; set; }
    }
}
