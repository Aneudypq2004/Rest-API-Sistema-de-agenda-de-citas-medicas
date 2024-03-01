using Medical.Application.Contracts.Persistence;
using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Medical.Persistence.Core
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly MedicalDbContext dbContext;

        private readonly DbSet<T> DbEntity;

        public BaseRepository(MedicalDbContext dbContext)
        {
            this.dbContext = dbContext;

            DbEntity = dbContext.Set<T>();
        }
        public virtual IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => DbEntity.Where(expression).AsNoTracking();

        public virtual IQueryable<T> FindAll() => DbEntity.AsNoTracking();

        public virtual void Create(T entity) => DbEntity.Add(entity);
        public virtual void Remove(T entity) => DbEntity.Remove(entity);
        public virtual void Update(T entity) => DbEntity.Update(entity);

        public async Task<T?> FindById(int Id) => await DbEntity.FindAsync(Id);
    }
}
