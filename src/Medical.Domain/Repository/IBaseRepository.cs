using System.Linq.Expressions;

namespace Medical.Application.Contracts.Persistence
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> FindAll();

        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);

        void Create(T entity);

        void Update(T entity);


        void Remove(T entity);
        Task<T?> FindById(int Id);
    }
}
