using Exams.Core.DTOs;
using FluentValidation;

namespace Exams.Service.Validations
{
    public class QuestionVMValidator : AbstractValidator<QuestionViewModel>
    {
        public QuestionVMValidator()
        {
            RuleFor(x => x.Quest)
               .NotNull()
               .WithMessage("Soru Boş Bırakılamaz")
               .MaximumLength(3000)
               .WithMessage("Cevap 3000 karakterden uzun olamaz.");
            RuleFor(x => x.Answer1)
                .NotNull()
                .WithMessage("A Şıkkı Boş Bırakılamaz")
                .MaximumLength(3000)
                .WithMessage("Şıkkı 3000 karakterden uzun olamaz.");
            RuleFor(x => x.Answer2)
                .NotNull()
                .WithMessage("B Şıkkı Boş Bırakılamaz")
                .MaximumLength(3000)
                .WithMessage("Cevap 3000 karakterden uzun olamaz.");
            RuleFor(x => x.Answer3)
                .NotNull()
                .WithMessage("C Şıkkı Boş Bırakılamaz")
                .MaximumLength(3000)
                .WithMessage("Cevap 3000 karakterden uzun olamaz.");
            RuleFor(x => x.Answer4)
                .NotNull()
                .WithMessage("D Şıkkı Boş Bırakılamaz")
                .MaximumLength(3000)
                .WithMessage("Cevap 3000 karakterden uzun olamaz.");
            RuleFor(x => x.Answer5)
                .NotNull()
                .WithMessage("E Şıkkı Boş Bırakılamaz")
                .MaximumLength(3000)
                .WithMessage("Cevap 3000 karakterden uzun olamaz.");
            RuleFor(x => x.TrueAnswer)
                .NotNull()
                .WithMessage("Doğru Cevabı İşaretleyiniz");
        }
    }
}