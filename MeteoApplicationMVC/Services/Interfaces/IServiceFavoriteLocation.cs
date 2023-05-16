using MeteoApplicationMVC.Models;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceFavoriteLocation
    {
        void CreateFavoriteLocation(FavoriteLocation favoriteLocation);
        void DeleteFavoriteLocation(FavoriteLocation favoriteLocation);
        FavoriteLocation GetFavoriteLocationById(int id);
        void UpdateFavoriteLocation(FavoriteLocation favoriteLocation);
        List<FavoriteLocation> GetAllFavoriteLocations();
        List<City> GetAllCities();
        City GetCityById(int? id);
        List<User> GetAllUsers();
        User GetUserById(string? id);
    }
}
