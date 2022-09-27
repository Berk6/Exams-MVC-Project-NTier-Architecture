using Exams.Core.Models;
using Exams.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exams.Repository.Repositories
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public SignUpRepository(AppDbContext context,  UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task AddRoleAsync(AppUser appUser, string userRole)
        {
            await _userManager.AddToRoleAsync(appUser, userRole);
        }

        public async Task<bool> AnyAsync(Expression<Func<AppUser, bool>> expression)
        {
           return await _context.Users.AnyAsync(expression);
        }

        public async Task<IdentityResult> CreateAsync(AppUser user, string password)
        {
            IdentityResult identityResult = await _userManager.CreateAsync(user, password);
            return identityResult;
        }
    }
}