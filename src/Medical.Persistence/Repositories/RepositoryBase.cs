using Medical.Application.Contracts.Persistence;
using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Medical.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly MedicalDbContext dbContext;

        public RepositoryBase(MedicalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => dbContext.Set<T>().Where(expression).AsNoTracking();

        public IQueryable<T> FindAll() => dbContext.Set<T>().AsNoTracking();

        public void Create(T entity) =>  dbContext.Set<T>().Add(entity);
        public void Remove(T entity) => dbContext.Set<T>().Remove(entity);
        public void Update(T entity) => dbContext.Set<T>().Update(entity);

    }
}
