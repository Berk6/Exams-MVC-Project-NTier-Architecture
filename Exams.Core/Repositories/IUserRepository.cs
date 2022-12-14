using Exams.Core.Models;

namespace Exams.Core.Repositories
{
    public interface IUserRepository
    {
        public AppUser FindUser(AppUser curUser);
        public void UpdateUser(AppUser curUser);
        public List<AppUser> UserIsAdded(AppUser curUser);
        public AppUser FindUserByUserName(string userName);
    }
}
