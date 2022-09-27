using Exams.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Exams.Core.Repositories
{
    public interface ILoginRepository
    {
        public  Task<AppUser> FindByNameAsync(string user);
        public Task<bool> IsLockedOutAsync(AppUser user);
        public Task GetAccessFailedCountAsync(AppUser user);
        public Task SignOutAsync();
        public Task<SignInResult> PasswordSignInAsync(AppUser user,string password,bool RememberMe,bool lockoutOnFailure);
    }
}
