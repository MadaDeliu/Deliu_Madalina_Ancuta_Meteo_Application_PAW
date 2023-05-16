using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;

namespace MeteoApplicationMVC.Repositories
{
    public class RepositorySevereWeatherEvents : RepositoryBase<SevereWeatherEvent>, IRepositorySevereWeatherEvents
    {
        public RepositorySevereWeatherEvents(ApplicationDbContext _applicationDbContext)
            : base(_applicationDbContext)
        {
        }
    }
}
