using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;

namespace MeteoApplicationMVC.Repositories
{
    public class RepositoryMeteorologist : RepositoryBase<Meteorologist>, IRepositoryMeteorologist
    {
        public RepositoryMeteorologist(ApplicationDbContext _applicationDbContext)
            : base(_applicationDbContext)
        {
        }
    }
}
