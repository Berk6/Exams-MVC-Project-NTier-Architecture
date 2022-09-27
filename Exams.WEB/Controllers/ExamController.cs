using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exams.WEB.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class ExamController : BaseController
    {
        private readonly IExamService _examService;
        public ExamController(IExamService examService, UserManager<AppUser> userManager) : base(userManager)
        {
            _examService = examService;
        }

        public IActionResult Index()
        {
            var allExam = _examService.GetAllExams(CurrentUser);
            return View(allExam);
        }
        public async Task<IActionResult> ViewResult()
        {
            var allResults = await _examService.ViewAllResults(CurrentUser);
            return View(allResults);
        }
        public IActionResult ViewTest(TestViewModel testViewModel)
        {
            if (testViewModel.Id != null)
            {
                var test = _examService.ViewTest(testViewModel, CurrentUser).Result;
                if (test == null || test.Question.Count == 0)
                {
                    ViewBag.Error = "Bu sınava daha önceden girdiğiniz için veya sınav soruları hazırlanmadığı için giriş yapamıyorsunuz";
                    return View();
                }
                return View(test);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> PostTest(TestViewModel completedTest)
        {
            if (completedTest == null)
                return RedirectToAction("Index");
            await _examService.PostTest(completedTest, CurrentUser);
            return RedirectToAction("ViewResult");
        }
    }
}
