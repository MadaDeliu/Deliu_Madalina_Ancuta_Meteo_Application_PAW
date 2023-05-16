using MeteoApplicationMVC.Models;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceCity
    {
        void CreateCity(City city);
        void DeleteCity(City city);
        City GetCityById(int id);
        void UpdateCity(City city);
        List<City> GetAllCities();
    }
}
