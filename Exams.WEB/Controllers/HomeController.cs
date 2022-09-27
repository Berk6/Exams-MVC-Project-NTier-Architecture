using Exams.Core.Models;
using Exams.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exams.WEB.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class HomeController : BaseController
    {
        private readonly IHomeService _homeService;

        public HomeController(IHomeService homeService, UserManager<AppUser> userManager):base(userManager)
        {
            _homeService = homeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var homeVM = await _homeService.Home(CurrentUser.UserName);
            return View(homeVM);
        }



    }
}