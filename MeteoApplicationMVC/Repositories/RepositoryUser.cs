using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;

namespace MeteoApplicationMVC.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(ApplicationDbContext _applicationDbContext)
            : base(_applicationDbContext)
        {
        }
    }
}
