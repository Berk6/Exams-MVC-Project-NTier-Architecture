using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers
{
    public class GuestController : Controller
   {
      public IActionResult Index()
        {
            return View();
        }
    }
}
