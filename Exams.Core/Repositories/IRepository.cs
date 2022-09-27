using System.Linq.Expressions;

namespace Exams.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        public Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void RemoveRange(IEnumerable<T> entities);
        void UpdateRange(IEnumerable<T> entities);
        void Remove(T entity);
    }
}
