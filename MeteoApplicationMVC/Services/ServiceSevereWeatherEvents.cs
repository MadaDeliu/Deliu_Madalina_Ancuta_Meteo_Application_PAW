using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeteoApplicationMVC.Services
{
    public class ServiceSevereWeatherEvents : IServiceSevereWeatherEvents
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ServiceSevereWeatherEvents(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateSevereWeatherEvents(SevereWeatherEvent severeWeatherEvent)
        {
            _repositoryWrapper.RepositorySevereWeatherEvents.Create(severeWeatherEvent);
            _repositoryWrapper.Save();
        }

        public void DeleteSevereWeatherEvents(SevereWeatherEvent severeWeatherEvent)
        {
            _repositoryWrapper.RepositorySevereWeatherEvents.Delete(severeWeatherEvent);
            _repositoryWrapper.Save();
        }

        public SevereWeatherEvent GetSevereWeatherEventsById(int id)
        {
            SevereWeatherEvent severeWeatherEvent = _repositoryWrapper.RepositorySevereWeatherEvents.FindByCondition(c => c.Id == id).First();
            return severeWeatherEvent;
        }

        public void UpdateSevereWeatherEvents(SevereWeatherEvent severeWeatherEvent)
        {
            _repositoryWrapper.RepositorySevereWeatherEvents.Update(severeWeatherEvent);
            _repositoryWrapper.Save();
        }

        public List<SevereWeatherEvent> GetAllSevereWeatherEvents()
        {
            List<SevereWeatherEvent> severeWeatherEvents = _repositoryWrapper.RepositorySevereWeatherEvents.FindAll().ToList();
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

