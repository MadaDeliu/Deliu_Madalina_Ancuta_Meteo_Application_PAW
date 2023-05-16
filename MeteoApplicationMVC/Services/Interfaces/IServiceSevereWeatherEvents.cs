using MeteoApplicationMVC.Models;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceSevereWeatherEvents
    {
        void CreateSevereWeatherEvents(SevereWeatherEvent severeWeatherEvent);
        void DeleteSevereWeatherEvents(SevereWeatherEvent severeWeatherEvent);
        SevereWeatherEvent GetSevereWeatherEventsById(int id);
        void UpdateSevereWeatherEvents(SevereWeatherEvent severeWeatherEvent);
        List<SevereWeatherEvent> GetAllSevereWeatherEvents();
        List<City> GetAllCities();
        City GetCityById(int? id);
    }
}
