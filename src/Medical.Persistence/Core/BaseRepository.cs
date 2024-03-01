using Medical.Application.Contracts.Persistence;
using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Medical.Persistence.Core
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly MedicalDbContext dbContext;

        private readonly DbSet<T> DbEntity;

        public BaseRepository(MedicalDbContext dbContext)
        {
            this.dbContext = dbContext;

            DbEntity = dbContext.Set<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => DbEntity.Where(expression).AsNoTracking();

        public IQueryable<T> FindAll() => DbEntity.AsNoTracking();

        public virtual void Create(T entity) => DbEntity.Add(entity);
        public virtual void Remove(T entity) => DbEntity.Remove(entity);
        public virtual void Update(T entity) => DbEntity.Update(entity);
    }
}
