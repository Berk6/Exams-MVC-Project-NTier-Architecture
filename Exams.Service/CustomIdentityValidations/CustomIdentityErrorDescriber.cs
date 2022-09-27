using Microsoft.AspNetCore.Identity;

namespace Indentity.CustomValidation
{
    public class CustomIdentityErrorDescriber : IdentityErrorDescriber
    {

        public override IdentityError InvalidUserName(string userName)
        {
            return new IdentityError() { Code = "InvalidUserName", Description = $"Belirttiğiniz {userName} kullanıcı adı geçersizdir." };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError() { Description = $"{userName} kullanıcı adı kullanılmaktadır." };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError() { Code = "DuplicateEmailYaDaNeistersekYazabiliriz", Description = $"{email} adresi kullanılmaktadır" };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() { Code = "PasswordTooShort", Description = $"Şifreniz en az {length} karakter olmalıdır." };
        }

    }
}
