using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeteoApplicationMVC.Services
{
    public class ServiceWeatherData : IServiceWeatherData
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ServiceWeatherData(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateWeatherData(WeatherData weatherData)
        {
            _repositoryWrapper.RepositoryWeatherData.Create(weatherData);
            _repositoryWrapper.Save();
        }

        public void DeleteWeatherData(WeatherData weatherData)
        {
            _repositoryWrapper.RepositoryWeatherData.Delete(weatherData);
            _repositoryWrapper.Save();
        }

        public WeatherData GetWeatherDataById(int id)
        {
            WeatherData weatherData = _repositoryWrapper.RepositoryWeatherData.FindByCondition(w => w.Id == id).First();
            return weatherData;
        }

        public void UpdateWeatherData(WeatherData weatherData)
        {
            _repositoryWrapper.RepositoryWeatherData.Update(weatherData);
            _repositoryWrapper.Save();
        }

        public List<WeatherData> GetAllWeatherDatas()
        {
            List<WeatherData> weatherDataList = _repositoryWrapper.RepositoryWeatherData.FindAll().ToList();
            return weatherDataList;
        }
        public List<Station> GetAllStations()
        {
            List<Station> station = _repositoryWrapper.RepositoryStation.FindAll().ToList();
            return station;
        }

        public Station GetStationById(int? id)
        {
            Station station;
            station = _repositoryWrapper.RepositoryStation.FindByCondition(r => r.Id == id).First();
            return station;
        }

    }
}

