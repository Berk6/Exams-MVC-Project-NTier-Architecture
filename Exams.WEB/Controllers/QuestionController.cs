using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Services;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Exams.WEB.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class QuestionController : BaseController
    {
        private readonly IQuestionService _questionService;
        private readonly ITestService _testService;

        public QuestionController(UserManager<AppUser> userManager, IQuestionService questionService, ITestService testService) : base(userManager)
        {
            _questionService = questionService;
            _testService = testService;
        }

        public IActionResult QuestionMaker()
        {
            return View();
        }
        [HttpPost]
        public IActionResult QuestionMaker(QuestionViewModel questionMakerDTO)
        {
            if (ModelState.IsValid)
            {
                questionMakerDTO.Creater = CurrentUser.Adapt<UserViewModel>();
                var data = _questionService.QuestionMaker(questionMakerDTO);
                if (data != null)
                {
                    TempData["info"] = "Soru başarılı bir şekilde kaydedilmiştir";
                    return RedirectToAction("QuestionMaker");
                }

            }
            return View(questionMakerDTO);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteQuestion([Bind(Prefix = "Item1")] List<QuestionViewModel> questionVM)
        {
            if (ModelState.IsValid)
            {
                await _questionService.DeleteQuestion(questionVM);
                return RedirectToAction("AllQuestions");
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateQuestion(QuestionViewModel questionVM)
        {
            if (ModelState.IsValid)
            {
                await _questionService.UpdateQuestion(questionVM);
            }
            return  RedirectToAction("AllQuestions");
        }
        [HttpGet]
        public async Task<IActionResult> AllQuestions()
        {
            var data = _questionService.AllQuestions(CurrentUser.Adapt<UserViewModel>());
            if (!data.AsEnumerable().Any())
            {
                ViewBag.NotFound = "Oluşturduğunuz herhangi bir soru bulunamamıştır";
            }
            var test = _testService.GetAllTestByCreater(CurrentUser.UserName);
            TestCreateViewModel testCreate = new TestCreateViewModel();
            if (test.Count > 0)
                testCreate.Tests.AddRange(test);
            var tuple = (data, testCreate);
            return View(tuple);
        }

    }
}
