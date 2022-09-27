using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.Core.Services
{
    public interface ITestService:IService<Test,TestViewModel>
    {
        public Task AddStudents(List<UserViewModel> userDTOs, int testId);
        public Task DeleteStudents(List<UserViewModel> userDTOs, int testId);
        public Task CreateTest(List<QuestionViewModel> quest, TestCreateViewModel test);
        public Task DeleteTest(List<TestViewModel> testVM);
        public List<TestViewModel> GetAllTestByCreater(string userName);
        public Task AddQuestionToTest(List<QuestionViewModel> questions, List<TestViewModel> testVM);
        public  Task DeleteQuestionToTest(TestViewModel testVm);
        public Task TestNameChange(List<TestViewModel> testViewModels);
        public List<UserViewModel> GetAllConnection(AppUser user);
        public List<ExamResultViewModel> ExamResults(TestViewModel test, AppUser curUser);
    }
}
