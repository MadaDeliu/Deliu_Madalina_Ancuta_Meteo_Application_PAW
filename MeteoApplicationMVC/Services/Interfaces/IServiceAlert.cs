using MeteoApplicationMVC.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceAlert
    {
        void CreateAlert(Alert alert);
        void DeleteAlert(Alert alert);
        Alert GetAlertById(int id);
        void UpdateAlert(Alert alert);
        List<Alert> GetAllAlerts();
        List<City> GetAllCities();
        City GetCityById(int? id);
        List<User> GetAllUsers();
        User GetUserById(string? id);

    }
}
