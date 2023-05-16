using MeteoApplicationMVC.Data;
using MeteoApplicationMVC.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MeteoApplicationMVC.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _applicationDbContext { get; set; }

        public RepositoryBase(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return this._applicationDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._applicationDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this._applicationDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this._applicationDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this._applicationDbContext.Set<T>().Remove(entity);
        }
    }
}
