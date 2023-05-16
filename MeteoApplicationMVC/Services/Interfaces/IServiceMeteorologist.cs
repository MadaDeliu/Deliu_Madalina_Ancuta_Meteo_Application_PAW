using MeteoApplicationMVC.Models;

namespace MeteoApplicationMVC.Services.Interfaces
{
    public interface IServiceMeteorologist
    {
        void CreateMeteorologist(Meteorologist meteorologist);
        void DeleteMeteorologist(Meteorologist meteorologist);
        Meteorologist GetMeteorologistById(int id);
        void UpdateMeteorologist(Meteorologist meteorologist);
        List<Meteorologist> GetAllMeteorologists();
        List<Station> GetAllStations();
        Station GetStationById(int? id);
    }
}
