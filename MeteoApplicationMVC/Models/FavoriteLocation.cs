namespace MeteoApplicationMVC.Models
{
    public class FavoriteLocation
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? CityId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public User? User { get; set; }
        public City? City { get; set; }
    }
}
