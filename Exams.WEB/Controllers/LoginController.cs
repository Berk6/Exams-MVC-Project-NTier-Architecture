using Exams.Core.DTOs;
using Exams.Core.Services;
using Exams.Service.Validations;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace Exams.WEB.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        public IActionResult Index(string ReturnUrl)
        {
            TempData["ReturnUrl"] = ReturnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO loginViewModel)
        {
            LoginValidator validationRules = new LoginValidator();
            ValidationResult result = validationRules.Validate(loginViewModel);
            if (result.IsValid)
            {
                if (ModelState.IsValid)
                {
                    var check = await _loginService.LoginAsync(loginViewModel);
                    if (check.StatusCode == 200)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else if (check.Errors.Any())
                    {
                        foreach (var item in check.Errors)
                        {
                            ModelState.AddModelError("", item);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(loginViewModel);
        }
    }
}