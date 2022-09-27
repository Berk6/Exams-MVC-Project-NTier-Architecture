using Exams.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Indentity.CustomValidation
{
    public class CustomUserValidator : IUserValidator<AppUser>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user)
        {


            List<IdentityError> error = new List<IdentityError>();

            if (int.TryParse(user.UserName[0].ToString(), out var value))
            {
                error.Add(new IdentityError() { Code = "FirstLetterOfTheUserNameIsANumber", Description = "Kullanıcı adının ilk hanesi sayı olamaz" });
            }

            if (error.Count > 0)
            {
                return await Task.FromResult(IdentityResult.Failed(error.ToArray()));
            }
            else
            {
                return await Task.FromResult(IdentityResult.Success);
            }
        }
    }
}
