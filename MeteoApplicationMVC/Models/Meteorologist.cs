namespace MeteoApplicationMVC.Models
{
    public class Meteorologist
    {
        public int Id { get; set; }
        public int? StationId { get; set; }
        public string? Name { get; set; }
        public string? Experience { get; set; }

        public Station? Station { get; set; }
    }
}
