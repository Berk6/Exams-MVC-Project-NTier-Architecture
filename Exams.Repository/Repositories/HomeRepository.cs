using Exams.Core.Models;
using Exams.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exams.Repository.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly AppDbContext _context;
        public HomeRepository(AppDbContext context)
        {
            _context = context;
        }
        public AppUser User(string name)
        {
           return _context.Users.FirstOrDefault(x=>x.UserName==name);
        }
        public  async Task<int> ConnectionsCount(AppUser user)
        {
            return await _context.Users
                .CountAsync(x => x.UserConnection.Contains(user) || x.MainUser.Contains(user));
        }

        public async Task<int> CreatedTest(AppUser user)
        {
            return await _context.TestModels.CountAsync(x => x.Creater == user);
        }

        public async Task<int> ExamsCount(AppUser user)
        {
            return await _context.TestModels.CountAsync(x => x.Users.Contains(user));
        }

        public async Task<int> QuestionsCount(AppUser user)
        {
            return await _context.Questions.CountAsync(x => x.Creater == user);
        }
    }
}
