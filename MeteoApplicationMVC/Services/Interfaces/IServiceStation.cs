using MeteoApplicationMVC.Models;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceStation
    {
        void CreateStation(Station station);
        void DeleteStation(Station station);
        Station GetStationById(int id);
        void UpdateStation(Station station);
        List<Station> GetAllStations();
        List<City> GetAllCities();
        City GetCityById(int? id);
    }
}
