using System.Linq.Expressions;

namespace Loyalty.Entities
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQueryable();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IQueryable<T> GetQueryable(jQueryDataTable.DynamicLinq.jQueryDataRequest param);
    }
}
