using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using MeteoApplicationMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MeteoApplicationMVC.Services
{
    public class ServiceMeteorologist : IServiceMeteorologist
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public ServiceMeteorologist(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public void CreateMeteorologist(Meteorologist meteorologist)
        {
            _repositoryWrapper.RepositoryMeteorologist.Create(meteorologist);
            _repositoryWrapper.Save();
        }

        public void DeleteMeteorologist(Meteorologist meteorologist)
        {
            _repositoryWrapper.RepositoryMeteorologist.Delete(meteorologist);
            _repositoryWrapper.Save();
        }

        public Meteorologist GetMeteorologistById(int id)
        {
            Meteorologist meteorologist = _repositoryWrapper.RepositoryMeteorologist.FindByCondition(m => m.Id == id).First();
            return meteorologist;
        }

        public void UpdateMeteorologist(Meteorologist meteorologist)
        {
            _repositoryWrapper.RepositoryMeteorologist.Update(meteorologist);
            _repositoryWrapper.Save();
        }

        public List<Meteorologist> GetAllMeteorologists()
        {
            List<Meteorologist> meteorologists = _repositoryWrapper.RepositoryMeteorologist.FindAll().ToList();
            return meteorologists;
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

