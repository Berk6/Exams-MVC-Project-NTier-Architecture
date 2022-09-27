using Exams.Core.Repositories;
using Exams.Core.Services;
using Exams.Core.UnitOfWorks;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exams.Service.Services
{
    public class Service<Model, DTO> : IService<Model, DTO> where Model : class where DTO : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Model> _repository;


        public Service(IUnitOfWork unitOfWork, IRepository<Model> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<DTO> AddAsync(DTO entity)
        {
            Model model = entity.Adapt<Model>();
            await _repository.AddAsync(model);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<DTO>> AddRangeAsync(IEnumerable<DTO> entities)
        {
            List<Model> model = entities.Adapt<List<Model>>();
            await _repository.AddRangeAsync(model);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<Model, bool>> expression)
        {
            return await _repository.AnyAsync(expression);
        }

        public async Task<IEnumerable<DTO>> GetAllAsync(Expression<Func<Model, bool>> expression)
        {
              var allModels=  await _repository.GetAllAsync().ToListAsync();
            List<DTO> allDTOs =allModels.Adapt<List<DTO>>();
            return allDTOs;
        }

        public async Task<DTO> GetByIdAsync(int id)
        {
               var Model= await _repository.GetByIdAsync(id);
            DTO dTO = Model.Adapt<DTO>();
            return dTO;
        }

        public async Task RemoveAsync(DTO entity)
        {
            Model model = entity.Adapt<Model>();
           _repository.Remove(model);
          await   _unitOfWork.CommitAsync();
            
        }

        public async Task RemoveRangeAsync(IEnumerable<DTO> entities)
        {
            List<Model> allDTOs = entities.Adapt<List<Model>>();
            _repository.RemoveRange(allDTOs);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(DTO entity)
        {
            Model model = entity.Adapt<Model>();
            _repository.Update(model);
            await _unitOfWork.CommitAsync();
        }
        public async Task UpdateRangeAsync(List<DTO> entities)
        {
            List<Model> models = entities.Adapt<List<Model>>();
             _repository.UpdateRange(models);
            await _unitOfWork.CommitAsync();   
        }

        public IEnumerable<DTO> Where(Expression<Func<Model, bool>> expression)
        {
               var model= _repository.Where(expression).ToList();

            return model.Adapt<List<DTO>>();
        }
    }
}
