using Exams.Core.DTOs;
using Exams.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Exams.WEB.Controllers
{
    public class SignUpController:Controller
    {
        private readonly ISignUpService _signUpService;

        public SignUpController(ISignUpService signUpService)
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
            if (ModelState.IsValid)
            {
        var res= await _signUpService.SignUpAsync(signUpDTO);
                if (res != null)
                {
                   return RedirectToAction("Index", "Login"); 
                }
            }
            
            return View(signUpDTO);
        }
    }
}
