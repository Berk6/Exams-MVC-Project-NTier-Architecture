using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.Core.Repositories
{
    public interface IExamRepository
    {
        public List<Test> GetAllExams(AppUser curUser);
        public bool ResultCheck(TestViewModel testViewModel, AppUser appUser);
        public Task ResultExam(ExamResult examResult);
        public Task<List<ExamResult>> ViewAllResults(AppUser curUser);
    }
}
