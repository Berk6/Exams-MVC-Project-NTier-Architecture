using Exams.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace Indentity.CustomValidation
{
    public class CustomPasswordValidator : IPasswordValidator<AppUser>
    {
        public async Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string password)
        {
            List<IdentityError> error = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                if (!password.ToLower().Contains(user.Email.ToLower().Substring(0, user.Email.IndexOf("@"))))
                {
                    error.Add(new IdentityError() { Code = "PasswordContainsUserName", Description = "Sifre kullanıcı adını içeremez.!" });
                }
            }
            if (password.Contains("1234"))
            {
                error.Add(new IdentityError() { Code = "PasswordContains1234", Description = "Şifre alanı ardışık sayı içeremez.!!" });
            }
            if (password.ToLower().Contains(user.Email.ToLower().Substring(0, user.Email.IndexOf("@"))))
            {
                error.Add(new IdentityError() { Code = "PasswordContainsEmail", Description = "Şifre email adresiyle aynı olamaz." });
            }
            if (error.Count == 0)
            {
                return await Task.FromResult(IdentityResult.Success);
            }
            else
            {
                return await Task.FromResult(IdentityResult.Failed(error.ToArray()));
            }

        }
    }
}
