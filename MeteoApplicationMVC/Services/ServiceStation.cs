using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeteoApplicationMVC.Services
{
    public class ServiceStation : IServiceStation
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ServiceStation(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateStation(Station station)
        {
            _repositoryWrapper.RepositoryStation.Create(station);
            _repositoryWrapper.Save();
        }

        public void DeleteStation(Station station)
        {
            _repositoryWrapper.RepositoryStation.Delete(station);
            _repositoryWrapper.Save();
        }

        public Station GetStationById(int id)
        {
            Station station = _repositoryWrapper.RepositoryStation.FindByCondition(s => s.Id == id).First();
            return station;
        }

        public void UpdateStation(Station station)
        {
            _repositoryWrapper.RepositoryStation.Update(station);
            _repositoryWrapper.Save();
        }

        public List<Station> GetAllStations()
        {
            List<Station> stations = _repositoryWrapper.RepositoryStation.FindAll().ToList();
            return stations;
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

