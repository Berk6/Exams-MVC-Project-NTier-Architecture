using Exams.Core.DTOs;
using Exams.Core.Services;
using Exams.Service.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Exams.Core.Models;

namespace Exams.WEB.Controllers
{
    public class SignUpController : BaseController
    {
        private readonly ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService,UserManager<AppUser> userManager) :base(userManager)
        {
            _signUpService = signUpService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignUpDTO signUpDTO)
        {
            SignUpValidator validationRules = new SignUpValidator();
            ValidationResult result1 = validationRules.Validate(signUpDTO);
            if (result1.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var res = await _signUpService.SignUpAsync(signUpDTO);
                    if (res.StatusCode == 201)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else 
                    {
                        AddModelError2(res);
                    }
                }
            }
            else
            {
                foreach (var item in result1.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View(signUpDTO);
        }
    }
}
