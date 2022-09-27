using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.Core.Repositories
{
    public interface IConnectionRepository
    {
        public List<AppUser> GetAllConnection(AppUser user);
        public List<AppUser> FindConnection(string name);
       public Task<AppUser> GetAllConnectionAnotherUser(string userName);
        public void RemoveConnectionWithAllegiances(UserViewModel model, AppUser currentUser, AppUser otherUser);
    }
}
