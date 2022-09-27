using Exams.Core.Models;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;

namespace Exams.Core.Repositories
{
    public interface ISignUpRepository
    {
        public Task<IdentityResult> CreateAsync(AppUser entity,string password);
        public Task AddRoleAsync(AppUser appUser, string userRole);
        Task<bool> AnyAsync(Expression<Func<AppUser, bool>> expression);
    }
}