using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Exams.WEB.Controllers
{
    [Authorize(Roles = "User,Admin")]
    public class TestController : BaseController
    {
        private readonly ITestService _testService;
        public TestController(UserManager<AppUser> userManager, ITestService testService) : base(userManager)
        {
            _testService = testService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrRemoveStudents([Bind(Prefix = "Item2")] List<UserViewModel> users)
        {
            if (ModelState.IsValid)
            {
                List<UserViewModel> userViewModelsAdded = new();
                List<UserViewModel> userViewModelsRemove = new();
                users.ForEach(x =>
                {
                    if (x.isAdded)
                    {
                        userViewModelsAdded.Add(x);
                    }
                    else
                    {
                        userViewModelsRemove.Add(x);
                    }
                });
                try
                {
                    await _testService.DeleteStudents(userViewModelsRemove, int.Parse(users[0].questId));
                    await _testService.AddStudents(userViewModelsAdded, int.Parse(users[0].questId));
                }
                catch
                {
                    TempData["GetAllTests"] = "Ekleme İşlemi Esnasında Bir Sorun Oluştu Daha Sonra Tekrar Deneyin";
                }
                return RedirectToAction("GetAllTests");
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTest([Bind(Prefix = "Item1")] List<QuestionViewModel> questionVM, [Bind(Prefix = "Item2")] TestCreateViewModel test)
        {
            if (ModelState.IsValid)
            {
                test.Creater = CurrentUser;
                await _testService.CreateTest(questionVM, test);
                return RedirectToAction("GetAllTests");
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTest(List<TestViewModel> testVM)
        {
            if (ModelState.IsValid)
            {
                await _testService.DeleteTest(testVM);
                TempData["GetAllTests"] = "Test Başarıyla Silinmiştir.";
                return RedirectToAction("GetAllTests");
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTests()
        {
            var allTests = _testService.GetAllTestByCreater(CurrentUser.UserName);
            if (!allTests.AsEnumerable().Any())
            {
                @ViewBag.NotFound = "Oluşturduğunuz herhangi bir test bulunamamıştır.";
                return View();
            }
            List<UserViewModel> userViewModel = _testService.GetAllConnection(CurrentUser);
            var tuple = (allTests, userViewModel);
            return View(tuple);
        }
        [HttpPost]
        public async Task<IActionResult> TestNameChange(List<TestViewModel> testViewModels)
        {
            await _testService.TestNameChange(testViewModels);
            return RedirectToAction("GetAllTests");
        }
        [HttpPost]
        public async Task<IActionResult> AddQuestionToTest([Bind(Prefix = "Item1")] List<QuestionViewModel> quest, [Bind(Prefix = "Item2")] TestCreateViewModel testCreateVM)
        {
            await _testService.AddQuestionToTest(quest, testCreateVM.Tests);
            return RedirectToAction("AllQuestions", "Question");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveQuestionToTest(TestViewModel testViewModels)
        {
            await _testService.DeleteQuestionToTest(testViewModels);
            TempData["GetAllTests"] = "Seçili Sorular Başarıyla Silinmiştir.";
            return RedirectToAction("GetAllTests");
        }
        [HttpPost]
        public IActionResult ExamResult(TestViewModel testVM)
        {
            if (testVM.Id != null)
            {
                var results = _testService.ExamResults(testVM, CurrentUser);
                if (results.Count > 0)
                {
                    return View(results);
                }
            }

                ViewBag.Error = "Sonuç Bulunamadı";
                return View();
        }
    }
}