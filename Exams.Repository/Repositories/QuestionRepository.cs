using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exams.Repository.Repositories
{
    public class QuestionRepository :GenericRepository<Question>,IQuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Question entity)
        {
            await _context.Questions.AddAsync(entity);
        }
        public  AppUser Creater(UserViewModel user)
        {
          var appUser= _context.Users.FirstOrDefault(x => x.UserName == user.UserName);
            return appUser;
        }
        public  async Task<Question> FirstOrDefaultAsync(int id)
        {
         var question= await  _context.Questions.Include(x=>x.Creater).FirstOrDefaultAsync(x=>x.Id==id);
            return question;
        }
    }
}
