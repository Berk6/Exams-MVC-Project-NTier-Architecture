using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exams.WEB.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class ConnectionController : BaseController
    {
        private readonly IConnectionService _connectionService;

        public ConnectionController(IConnectionService connectionService, UserManager<AppUser> userManager) : base(userManager)
        {
            _connectionService = connectionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AllConnections(int pg = 1)
        {
            var allConAndPage = _connectionService.GetAllConnection(CurrentUser, pg);
            if (allConAndPage.Item1.Count == 0)
            {
                ViewBag.NotFound = "Herhangi bir bağlantınız bulunmamaktadır.";
                return View();
            }
            this.ViewBag.Pager = allConAndPage.Item2;
            return View(allConAndPage.Item1);
        }
        [HttpGet]
        [Route("Connection/FindConnection/{name?}")]
        public IActionResult FindConnection(string name, int pg = 1)
        {
            if (TempData["page"] != null)
            {
                var a = TempData["page"]?.ToString();
                pg = int.Parse(a);
            }

            if (name == null)
            {
                ViewBag.NotFound = "Kullanıcı adını yazarak arama yapınız.";
                return View();
            }
            else
            {
                var result = _connectionService.FindConnection(name, CurrentUser, pg);
                if (result.Item1 == null) { ViewBag.NotFound = "Kullanıcı bulunamadı"; return View(); }
                ViewBag.Pager = result.Item2;
                return View(result.Item1);
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveConnection(UserViewModel model)
        {
           var result=await _connectionService.RemoveConnection(model, CurrentUser);
            if (result.StatusCode == 404)
            {
                TempData["error"] = result.Errors;
            }
            if (model.Page == null)
            {
                return Redirect($"/User/ViewProfile/{model.UserName}");
            }
            if (model.Search == null)
            {
                return RedirectToAction("AllConnections");
            }

            TempData["page"] = model.Page;
            return Redirect($"FindConnection/{model.Search}");
        }
        [HttpPost]
        public async Task<IActionResult> AddConnection(UserViewModel model)
        {
            if (model == null) RedirectToAction("Index", "Home");
            var result =await _connectionService.AddConnection(model, CurrentUser);

            if (result.StatusCode == 400)
            {
                TempData["page"] = model.Page;
                return Redirect($"FindConnection/{model.Search}");
            }
            if (model.Page == null)
            {
                return Redirect($"/User/ViewProfile/{model.UserName}");
            }
            TempData["page"] = model.Page;
            return Redirect($"FindConnection/{model.Search}");
        }
    }
}