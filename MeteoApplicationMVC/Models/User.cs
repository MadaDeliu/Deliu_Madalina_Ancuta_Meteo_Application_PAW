using Google.Apis.Admin.Directory.directory_v1.Data;
using Microsoft.AspNetCore.Identity;

namespace MeteoApplicationMVC.Models
{
    public class User: IdentityUser
    {
        public override string? UserName { get; set; }
        public override string? Email { get; set; }
        public string? Password { get; set; }
        public string? HashPassword { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? urlPicture { get; set; }
        public ICollection<FavoriteLocation>? FavoriteLocations { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
        public ICollection<Alert>? Alerts { get; set; }
    }
}
