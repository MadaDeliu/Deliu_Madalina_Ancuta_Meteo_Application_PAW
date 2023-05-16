using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeteoApplicationMVC.Services
{
    public class ServiceAlert : IServiceAlert
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ServiceAlert(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateAlert(Alert alert)
        {
            _repositoryWrapper.RepositoryAlert.Create(alert);
            _repositoryWrapper.Save();
        }

        public void DeleteAlert(Alert alert)
        {
            _repositoryWrapper.RepositoryAlert.Delete(alert);
            _repositoryWrapper.Save();
        }

        public Alert GetAlertById(int id)
        {
            Alert alert = _repositoryWrapper.RepositoryAlert.FindByCondition(c => c.Id == id).First();
            return alert;
        }

        public void UpdateAlert(Alert alert)
        {
            _repositoryWrapper.RepositoryAlert.Update(alert);
            _repositoryWrapper.Save();
        }

        public List<Alert> GetAllAlerts()
        {
            List<Alert> alerts = _repositoryWrapper.RepositoryAlert.FindAll().ToList();
            return alerts;
        }

        public List<City> GetAllCities()
        {
            List<City> cities = _repositoryWrapper.RepositoryCity.FindAll().ToList();
            return cities;
        }

        public City GetCityById(int? id)
        {
            City city;
            city = _repositoryWrapper.RepositoryCity.FindByCondition(r => r.Id == id).First();
            return city;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = _repositoryWrapper.RepositoryUser.FindAll().ToList();
            return users;
        }

        public User GetUserById(string? id)
        {
            User user;
            user = _repositoryWrapper.RepositoryUser.FindByCondition(r => r.Id == id).First();
            return user;
        }
    }
}
