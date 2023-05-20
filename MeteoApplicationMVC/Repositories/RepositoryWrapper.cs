using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Repositories.Interfaces;

namespace MeteoApplicationMVC.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private IRepositoryAlert? _alertRepository;
        private IRepositoryCity? _cityRepository;
        private IRepositoryContact? _contactRepository;
        private IRepositoryFavoriteLocation? _favoriteLocationRepository;
        private IRepositoryMeteorologist? _meteorologistRepository;
        private IRepositoryNews? _severeWeatherEventsRepository;
        private IRepositoryStation? _stationRepository;
        private IRepositoryUser? _userRepository;
        private IRepositoryWeatherData? _weatherDataRepository;

        public IRepositoryAlert RepositoryAlert
        {
            get
            {
                if (_alertRepository == null)
                {
                    _alertRepository = new RepositoryAlert(_applicationDbContext);
                }
                return _alertRepository;
            }
        }

        public IRepositoryCity RepositoryCity
        {
            get
            {
                if (_cityRepository == null)
                {
                    _cityRepository = new RepositoryCity(_applicationDbContext);
                }
                return _cityRepository;
            }
        }

        public IRepositoryContact RepositoryContact
        {
            get
            {
                if (_contactRepository == null)
                {
                    _contactRepository = new RepositoryContact(_applicationDbContext);
                }
                return _contactRepository;
            }
        }

        public IRepositoryFavoriteLocation RepositoryFavoriteLocation
        {
            get
            {
                if (_favoriteLocationRepository == null)
                {
                    _favoriteLocationRepository = new RepositoryFavoriteLocation(_applicationDbContext);
                }
                return _favoriteLocationRepository;
            }
        }

        public IRepositoryMeteorologist RepositoryMeteorologist
        {
            get
            {
                if (_meteorologistRepository == null)
                {
                    _meteorologistRepository = new RepositoryMeteorologist(_applicationDbContext);
                }
                return _meteorologistRepository;
            }
        }

        public IRepositoryNews RepositorySevereWeatherEvents
        {
            get
            {
                if (_severeWeatherEventsRepository == null)
                {
                    _severeWeatherEventsRepository = new RepositoryNews(_applicationDbContext);
                }
                return _severeWeatherEventsRepository;
            }
        }

        public IRepositoryStation RepositoryStation
        {
            get
            {
                if (_stationRepository == null)
                {
                    _stationRepository = new RepositoryStation(_applicationDbContext);
                }
                return _stationRepository;
            }
        }

        public IRepositoryUser RepositoryUser
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new RepositoryUser(_applicationDbContext);
                }
                return _userRepository;
            }
        }

        public IRepositoryWeatherData RepositoryWeatherData
        {
            get
            {
                if (_weatherDataRepository == null)
                {
                    _weatherDataRepository = new RepositoryWeatherData(_applicationDbContext);
                }
                return _weatherDataRepository;
            }
        }

        public RepositoryWrapper(ApplicationDbContext dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public void Save()
        {
            _applicationDbContext.SaveChanges();
        }
    }
}
