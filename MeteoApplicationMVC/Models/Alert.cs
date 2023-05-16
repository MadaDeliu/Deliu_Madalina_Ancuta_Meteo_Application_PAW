namespace MeteoApplicationMVC.Models
{
    public class Alert
    {
        public int Id { get; set; }
        public int? CityId { get; set; }

        public string? UserId { get; set; }
        public string? Type { get; set; }
        public double? ThresholdValue { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public City? City { get; set; }

        public User? User { get; set; }
    }
}
