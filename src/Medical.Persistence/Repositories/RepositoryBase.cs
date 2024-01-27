using Medical.Application.Contracts.Persistence;
using Medical.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Persistence.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;

        public RepositoryBase(ApplicationDbContext dbContext)
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
