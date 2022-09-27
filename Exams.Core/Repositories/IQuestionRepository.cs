using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.Core.Repositories
{
    public interface IQuestionRepository:IRepository<Question>
    {
        public AppUser Creater(UserViewModel user);
        public Task<Question> FirstOrDefaultAsync(int id);
    }
}
