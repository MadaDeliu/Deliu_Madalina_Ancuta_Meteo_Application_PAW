using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MeteoApplicationMVC.Repositories
{
    public class RepositoryAlert : RepositoryBase<Alert>, IRepositoryAlert
    {
        public RepositoryAlert(ApplicationDbContext _applicationDbContext)
            : base(_applicationDbContext)
        {
        }
    }
}
