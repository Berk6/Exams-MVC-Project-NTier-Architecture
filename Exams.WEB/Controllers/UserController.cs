using Exams.Core.DTOs;
using Exams.Core.Enums;
using Exams.Core.Models;
using Exams.Core.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Exams.WEB.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class UserController : BaseController
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IUserService userService) : base(userManager)
        {
            _signInManager = signInManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [Route("User/ViewProfile")]
        public IActionResult ViewProfile()
        {
            UserViewModel model = CurrentUser.Adapt<UserViewModel>();
            return View(model);
        }
        public IActionResult LogOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Settings()
        {
            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            ViewBag.Country = new SelectList(Enum.GetNames(typeof(Country)));
            ViewBag.Education = new SelectList(Enum.GetNames(typeof(EducationStatus)));
            UserSettingsViewModel model = CurrentUser.Adapt<UserSettingsViewModel>();

            return View(model);
        }
        [HttpPost]
        public IActionResult Settings(UserSettingsViewModel model)
        {
            if (ModelState.IsValid)
            {
                _userService.Settings(model, CurrentUser);
                TempData["success"] = true;
                return RedirectToAction("Settings");
            }

            ViewBag.Gender = new SelectList(Enum.GetNames(typeof(Gender)));
            ViewBag.Country = new SelectList(Enum.GetNames(typeof(Country)));
            ViewBag.Education = new SelectList(Enum.GetNames(typeof(EducationStatus)));
            ViewBag.Error = "Kayıt işlemi başarısız oldu";
            return View(model);
        }

    }
}
