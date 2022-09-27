using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.Core.Repositories
{
    public interface ITestRepository:IRepository<Test>
    {
        public void AddStudentsToTest(List<AppUser> appUsers, Test tests);
        public void DeleteStudentsToTest(List<AppUser> appUsers, Test tests);
        public Task CreateTest(Test test);
        public void DeleteTest(List<Test> test);
        public List<Test> GetTestCreaterAsync(string userName);
        public List<Test> GetAllTestWithAllColumnByCreater(AppUser appUser);
        public Task<Test> GetTestWithAllColumnByIdAsync(int testId);
        public Task<Test> GetTestByIdAsync(TestViewModel testVM);
        public Test GetTestById(TestViewModel testVM);
        public void DeleteQuestionToTest(List<Question> questions, Test tests);
        public void AddQuestionToTest(List<Question> questions, Test tests);
        public List<ExamResult> ExamResults(TestViewModel test, AppUser curUser);
    }
}
