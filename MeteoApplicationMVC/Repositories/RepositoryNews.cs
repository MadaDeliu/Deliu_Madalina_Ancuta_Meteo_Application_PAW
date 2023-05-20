using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Models;
using MeteoApplicationMVC.Repositories.Interfaces;

namespace MeteoApplicationMVC.Repositories
{
    public class RepositoryNews : RepositoryBase<News>, IRepositoryNews
    {
        public RepositoryNews(ApplicationDbContext _applicationDbContext)
            : base(_applicationDbContext)
        {
        }
    }
}
