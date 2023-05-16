using static System.Collections.Specialized.BitVector32;

namespace MeteoApplicationMVC.Models
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CountryCode { get; set; }
        
        public ICollection<Station>? Stations { get; set; }
        public ICollection<FavoriteLocation>? FavoriteLocations { get; set; }
        public ICollection<Alert>? Alerts { get; set; }

        public ICollection<SevereWeatherEvent>? SevereWeatherEvents { get; set; }
    }
}
