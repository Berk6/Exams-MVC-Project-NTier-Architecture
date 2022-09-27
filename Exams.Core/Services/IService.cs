using System.Linq.Expressions;

namespace Exams.Core.Services
{
    public interface IService<Model, DTO> where Model : class where DTO : class
    {
        Task<DTO> GetByIdAsync(int id);
        Task<IEnumerable<DTO>> GetAllAsync(Expression<Func<Model, bool>> expression);
        IEnumerable<DTO> Where(Expression<Func<Model, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<Model, bool>> expression);
        Task<DTO> AddAsync(DTO entity);
        Task<IEnumerable<DTO>> AddRangeAsync(IEnumerable<DTO> entities);
        Task UpdateAsync(DTO entity);
        Task RemoveRangeAsync(IEnumerable<DTO> entities);
        public  Task UpdateRangeAsync(List<DTO> entities);
        Task RemoveAsync(DTO entity);
    }
}
