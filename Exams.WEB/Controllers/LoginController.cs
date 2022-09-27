using Exams.Core.DTOs;
using Exams.Core.Services;
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
            if (ModelState.IsValid)
            {
                var check = await _loginService.LoginAsync(loginViewModel);
                if (check != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginViewModel);
        }
    }
}