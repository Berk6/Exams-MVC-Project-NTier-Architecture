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
        public AppUser FindUserByUserName(string userName)
        {
           return _context.Users.FirstOrDefault(x => x.UserName == userName);
        }
        public List<AppUser> UserIsAdded(AppUser curUser)
        {
           return _context.Users
                  .Where(x => x.UserConnection.Contains(curUser) || x.MainUser.Contains(curUser))
                  .ToList();
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
