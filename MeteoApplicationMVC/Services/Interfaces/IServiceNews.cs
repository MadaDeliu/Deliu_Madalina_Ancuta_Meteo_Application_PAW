using MeteoApplicationMVC.Models;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceNews
    {
        void CreateNews(News severeWeatherEvent);
        void DeleteNews(News severeWeatherEvent);
        News GetSevereWeatherEventsById(int id);
        void UpdateSevereWeatherEvents(News severeWeatherEvent);
        List<News> GetAllSevereWeatherEvents();
        List<City> GetAllCities();
        City GetCityById(int? id);
    }
}
