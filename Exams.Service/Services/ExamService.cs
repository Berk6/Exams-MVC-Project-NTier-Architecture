using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Exams.Core.Services;
using Exams.Core.UnitOfWorks;
using Mapster;

namespace Exams.Service.Services
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _examRepository;
        private readonly ITestRepository _testRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ExamService(IExamRepository examRepository, ITestRepository testRepository, IUnitOfWork unitOfWork)
        {
            _examRepository = examRepository;
            _testRepository = testRepository;
            _unitOfWork = unitOfWork;
        }

        public List<TestViewModel> GetAllExams(AppUser curUser)
        {
       var examResults= _examRepository.ViewAllResults(curUser).Result;
            var allExams = _examRepository.GetAllExams(curUser);
            List<TestViewModel> verifiedTests = new();
            foreach  (var test in allExams)
            {
                bool check = true;
                foreach (var result in examResults)
                {
                    if(result.Exam.Id == test.Id)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    verifiedTests.Add(test.Adapt<TestViewModel>());
                }
            }

            return verifiedTests;
        }

        public Task<bool> PostTest(TestViewModel completedTest, AppUser curUser)
        {
            var selectedTest = _testRepository.GetTestWithAllColumnByIdAsync(completedTest.Id.Value);
            int trueAns = 0;
            int falseAns = 0;
            foreach (var item2 in selectedTest.Result.Question)
            {
                foreach (var item in completedTest.Question)
                {
                    if (item.Id == item2.Id)
                    {
                        if (item2.TrueAnswer == item.TrueAnswer)
                        {
                            trueAns++;
                        }
                        else
                        {
                            falseAns++;
                        }
                    }
                }
            }
            float totalScore = 100f;
            float result = (totalScore / completedTest.Question.Count) * trueAns;
            ExamResult examResult = new ExamResult
            {
                Exam = selectedTest.Result,
                Result = result,
                Student = curUser
            };
            _examRepository.ResultExam(examResult);
            _unitOfWork.CommitAsync();
            return Task.FromResult(true);
        }

        public async Task<List<ExamResultViewModel>> ViewAllResults(AppUser curUser)
        {
        var results=  await  _examRepository.ViewAllResults(curUser);
            return results.Adapt<List<ExamResultViewModel>>();
        }

        public async Task<TestViewModel> ViewTest(TestViewModel testViewModel, AppUser curUser)
        {
            var result = _examRepository.ResultCheck(testViewModel, curUser);
            if (result) return null;
            Test test = new();
            try
            {
             test = await _testRepository.GetTestWithAllColumnByIdAsync(testViewModel.Id.Value);
                test.Question.ForEach(x => x.TrueAnswer = null);
            }
            catch
            {
                return null;
            }

            return test.Adapt<TestViewModel>();
        }
    }
}
