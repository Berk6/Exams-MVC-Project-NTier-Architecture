using Exams.Core.Models;
using Exams.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Exams.Repository.Repositories
{
    public class LoginRepository: ILoginRepository
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginRepository(AppDbContext context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<AppUser> FindByNameAsync(string user)
        {
            AppUser userCheck = await _userManager.FindByNameAsync(user);
            if(userCheck != null)
            {
                return userCheck;
            }
            else
            {
            return null;
            }
        }

        public async Task GetAccessFailedCountAsync(AppUser user)
        {
          await  _userManager.GetAccessFailedCountAsync(user);
        }

        public async Task<bool> IsLockedOutAsync(AppUser user)
        {
          return  await _userManager.IsLockedOutAsync(user);
        }

        public async Task<SignInResult> PasswordSignInAsync(AppUser user, string password, bool RememberMe, bool lockoutOnFailure)
        {
        return   await _signInManager.PasswordSignInAsync(user,password,RememberMe,lockoutOnFailure);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
