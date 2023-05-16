using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeteoApplicationMVC.Services
{
    public class ServiceCity : IServiceCity
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        public ServiceCity(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateCity(City city)
        {
            _repositoryWrapper.RepositoryCity.Create(city);
            _repositoryWrapper.Save();
        }

        public void DeleteCity(City city)
        {
            _repositoryWrapper.RepositoryCity.Delete(city);
            _repositoryWrapper.Save();
        }

        public City GetCityById(int id)
        {
            City city = _repositoryWrapper.RepositoryCity.FindByCondition(c => c.Id == id).First();
            return city;
        }

        public void UpdateCity(City city)
        {
            _repositoryWrapper.RepositoryCity.Update(city);
            _repositoryWrapper.Save();
        }

        public List<City> GetAllCities()
        {
            List<City> cities = _repositoryWrapper.RepositoryCity.FindAll().ToList();
            return cities;
        }
    }
}