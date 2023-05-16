using MeteoApplicationMVC.Models;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceWeatherData
    {
        void CreateWeatherData(WeatherData weatherData);
        void DeleteWeatherData(WeatherData weatherData);
        WeatherData GetWeatherDataById(int id);
        void UpdateWeatherData(WeatherData weatherData);
        List<WeatherData> GetAllWeatherDatas();
        List<Station> GetAllStations();
        Station GetStationById(int? id);
    }
}
