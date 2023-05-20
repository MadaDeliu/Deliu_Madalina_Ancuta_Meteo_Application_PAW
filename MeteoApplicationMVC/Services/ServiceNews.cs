using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeteoApplicationMVC.Services
{
    public class ServiceNews : IServiceNews
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ServiceNews(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateNews(News severeWeatherEvent)
        {
            _repositoryWrapper.RepositorySevereWeatherEvents.Create(severeWeatherEvent);
            _repositoryWrapper.Save();
        }

        public void DeleteNews(News severeWeatherEvent)
        {
            _repositoryWrapper.RepositorySevereWeatherEvents.Delete(severeWeatherEvent);
            _repositoryWrapper.Save();
        }

        public News GetSevereWeatherEventsById(int id)
        {
            News severeWeatherEvent = _repositoryWrapper.RepositorySevereWeatherEvents.FindByCondition(c => c.Id == id).First();
            return severeWeatherEvent;
        }

        public void UpdateSevereWeatherEvents(News severeWeatherEvent)
        {
            _repositoryWrapper.RepositorySevereWeatherEvents.Update(severeWeatherEvent);
            _repositoryWrapper.Save();
        }

        public List<News> GetAllSevereWeatherEvents()
        {
            List<News> severeWeatherEvents = _repositoryWrapper.RepositorySevereWeatherEvents.FindAll().ToList();
            return severeWeatherEvents;
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
    }
}

