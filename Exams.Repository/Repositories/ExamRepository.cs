using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exams.Repository.Repositories
{
    public class ExamRepository :IExamRepository
    {
        private readonly AppDbContext _context;

        public ExamRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Test> GetAllExams(AppUser curUser)
        {
           var user= _context.Users.FirstOrDefault(x => x.Id == curUser.Id);
            var exams= _context.TestModels
                .Include(x => x.Creater)
                 .Where(x => x.Users.Contains(user))
                 .ToList();
            return exams;
        }
        public Test GetTestWithQuestion(TestViewModel testViewModel)
        {
           return _context.TestModels.Include(x=>x.Question).Include(x=>x.Users).FirstOrDefault(x=>x.Id==testViewModel.Id);
        }

        public bool ResultCheck(TestViewModel testVM, AppUser appUser)
        {
            var resultCheck = _context.ExamResults
                      .FirstOrDefault(x => x.Student.Id == appUser.Id && x.Exam.Id == testVM.Id);
            if (resultCheck == null) return false;
            return true;
        }

        public async Task ResultExam(ExamResult examResult)
        {
           await _context.AddAsync(examResult);
        }

        public async Task<List<ExamResult>> ViewAllResults(AppUser curUser)
        {
            return await _context.ExamResults.Include(x=>x.Exam).ThenInclude(x=>x.Creater).Where(x=>x.Student==curUser).ToListAsync();
             
        }
    }
}
