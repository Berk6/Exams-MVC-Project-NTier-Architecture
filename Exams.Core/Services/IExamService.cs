using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.Core.Services
{
    public interface IExamService
    {
        public List<TestViewModel> GetAllExams(AppUser curUser);
        public Task<TestViewModel> ViewTest(TestViewModel testViewModel, AppUser curUser);
        public Task<bool> PostTest(TestViewModel testViewModel, AppUser curUser);
        public Task<List<ExamResultViewModel>> ViewAllResults(AppUser curUser);
    }
}
