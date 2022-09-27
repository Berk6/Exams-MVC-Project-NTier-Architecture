using Exams.Core.Models;
using Exams.Core.Repositories;

namespace Exams.Repository.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public AppUser FindUser(AppUser curUser)
        {
           return _context.Users.FirstOrDefault(curUser);
        }
        public void UpdateUser(AppUser curUser)
        {
            _context.Update(curUser);
        }
    }
}
