using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exams.Repository.Repositories
{
    public class ConnectionRepository:GenericRepository<AppUser>,IConnectionRepository
    {
        private readonly AppDbContext _context;

        public ConnectionRepository(AppDbContext context):base(context)
        {
            _context = context;
        }

        public  List<AppUser> GetAllConnection(AppUser user)
        {
          return _context.Users
                .Where(x => x.MainUser.Contains(user) || x.UserConnection.Contains(user))
                .ToList();
        }
        public async Task<AppUser> GetAllConnectionAnotherUser(string userName)
        {
            var user =await _context.Users
               .Include(x => x.MainUser)
               .Include(x => x.UserConnection)
               .FirstOrDefaultAsync(x => x.UserName == userName);
            return user;
        }
        public List<AppUser> FindConnection(string name)
        {
            List<AppUser> info = _context.Users
                   .Where(x => x.NormalizedUserName.Contains(name.ToUpper()))
                   .OrderBy(x => x.UserName)
                   .ToList();
            return info;
        } 
        public void RemoveConnectionWithAllegiances(UserViewModel model, AppUser currentUser,AppUser otherUser)
        {
            var tests = _context.TestModels
                 .Include(x => x.Users)
                 .Where(x => x.Creater == currentUser && x.Users.Contains(otherUser) || x.Creater == otherUser && x.Users.Contains(currentUser))
               .ToList();
            tests.ForEach(x =>
            {
                x.Users.Remove(otherUser);
                x.Users.Remove(currentUser);
            });
        }
    }
}
