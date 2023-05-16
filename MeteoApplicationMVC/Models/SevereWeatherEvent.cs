namespace MeteoApplicationMVC.Models
{
    public class SevereWeatherEvent
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int? CityId { get; set; }
        public double? Severity { get; set; }
        public string? Code { get; set; }
        public DateTime? Date { get; set; }

        public City? City { get; set; }
    }
}
