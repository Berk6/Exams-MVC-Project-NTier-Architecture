using Exams.Core.DTOs;
using Exams.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exams.WEB.Controllers
{
    public class BaseController : Controller
    {
        protected UserManager<AppUser> userManager { get; }
        protected AppUser CurrentUser => userManager.FindByNameAsync(User.Identity.Name).Result;
        public BaseController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public void AddModelError(IdentityResult result)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }
        public void AddModelError2(CustomResponseDto<SignUpDTO> result)
        {
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item);
            }
        }
    }
}
