using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeteoApplicationMVC.Services
{
    public class ServiceFavoriteLocation : IServiceFavoriteLocation
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ServiceFavoriteLocation(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateFavoriteLocation(FavoriteLocation favoriteLocation)
        {
            _repositoryWrapper.RepositoryFavoriteLocation.Create(favoriteLocation);
            _repositoryWrapper.Save();
        }

        public void DeleteFavoriteLocation(FavoriteLocation favoriteLocation)
        {
            _repositoryWrapper.RepositoryFavoriteLocation.Delete(favoriteLocation);
            _repositoryWrapper.Save();
        }

        public FavoriteLocation GetFavoriteLocationById(int id)
        {
            FavoriteLocation favoriteLocation = _repositoryWrapper.RepositoryFavoriteLocation.FindByCondition(fl => fl.Id == id).First();
            return favoriteLocation;
        }

        public void UpdateFavoriteLocation(FavoriteLocation favoriteLocation)
        {
            _repositoryWrapper.RepositoryFavoriteLocation.Update(favoriteLocation);
            _repositoryWrapper.Save();
        }

        public List<FavoriteLocation> GetAllFavoriteLocations()
        {
            List<FavoriteLocation> favoriteLocations = _repositoryWrapper.RepositoryFavoriteLocation.FindAll().ToList();
            return favoriteLocations;
        }

        public List<City> GetAllCities()
        {
            List<City> cities = _repositoryWrapper.RepositoryCity.FindAll().ToList();
            return cities;
        }

        public City GetCityById(int? id)
        {
            City city = _repositoryWrapper.RepositoryCity.FindByCondition(c => c.Id == id).FirstOrDefault();
            return city;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = _repositoryWrapper.RepositoryUser.FindAll().ToList();
            return users;
        }

        public User GetUserById(string? id)
        {
            User user = _repositoryWrapper.RepositoryUser.FindByCondition(u => u.Id == id).FirstOrDefault();
            return user;
        }
    }
}

