using Exams.Core.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Service.Validations
{
    public class LoginValidator:AbstractValidator<LoginDTO>
    {
        public LoginValidator()
        {
            RuleFor(x => x.UserName)
               .NotNull().WithMessage("Kullanıcı Adı Boş Bırakılamaz")
               .MinimumLength(6).WithMessage("Kullanıcı Adı Minimum 6 Karakterden Oluşmalıdır")
               .MaximumLength(20).WithMessage("Kullanıcı Adı Maksimum 20 Karakterden Oluşmalıdır");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Şifre Boş Bırakılamaz")
                .MinimumLength(6).WithMessage("Şifre Minimum 6 Karakterden Oluşmalıdır")
                .MaximumLength(20).WithMessage("Şifre Maksimum 20 Karakterden Oluşmalıdır");
        }
    }
}
