using Exams.Core.DTOs;
using FluentValidation;

namespace Exams.Service.Validations
{
    public class SignUpValidator :AbstractValidator<SignUpDTO>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull().WithMessage("Kullanıcı Adı Boş Bırakılamaz")
                .MinimumLength(6).WithMessage("Kullanıcı Adı Minimum 6 Karakterden Oluşmalıdır")
                .MaximumLength(20).WithMessage("Kullanıcı Adı Maksimum 20 Karakterden Oluşmalıdır");

            RuleFor(x => x.Password)
                .NotNull().WithMessage("Şifre Boş Bırakılamaz")
                .MinimumLength(6).WithMessage("Şifre Minimum 6 Karakterden Oluşmalıdır")
                .MaximumLength(20).WithMessage("Şifre Maksimum 20 Karakterden Oluşmalıdır");


            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email Boş Bırakılamaz")
                .EmailAddress().WithMessage("Mail adresinizi kontrol ediniz");
        }
    }
}
