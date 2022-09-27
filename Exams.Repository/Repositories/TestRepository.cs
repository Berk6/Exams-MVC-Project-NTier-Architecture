using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Exams.Repository.Repositories
{
    public class TestRepository : GenericRepository<Test>, ITestRepository
    {
        private readonly AppDbContext _context;
        public TestRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void AddStudentsToTest(List<AppUser> appUsers, Test tests)
        {
            for (int i = 0; i < appUsers.Count; i++)
            {
         var user=   _context.Users.FirstOrDefault(x => x.UserName == appUsers[i].UserName);

            tests.Users.Add(user);
            }
        }
        public void DeleteStudentsToTest(List<AppUser> appUsers, Test test)
        {
            var orgTest = _context.TestModels.Include(x => x.Users).FirstOrDefault(x => x.Id == test.Id);
            for (int i = 0; i < appUsers.Count; i++)
            {
                var user = _context.Users.FirstOrDefault(x => x.UserName == appUsers[i].UserName);
                orgTest.Users.Remove(user);
            }
        }
        public async Task CreateTest(Test test)
        {
            await _context.AddAsync(test);
        }
        public void DeleteTest(List<Test> test)
        {
            _context.RemoveRange(test);
        }
        public List<Test> GetAllTestWithAllColumnByCreater(AppUser appUser)
        {
            var tests= _context.TestModels
                    .Include(x => x.Users)
                    .Include(x => x.Question)
                    .Where(own => own.Creater.UserName == appUser.UserName)
                    .ToList();
            return tests;
        }
        public async Task<Test> GetTestWithAllColumnByIdAsync(int testVmId)
        {
            return await _context.TestModels
                    .Include(x => x.Users)
                    .Include(x => x.Question)
                    .FirstOrDefaultAsync(testId => testId.Id == testVmId);
        }
        public async Task<Test> GetTestByIdAsync(TestViewModel testVM)
        {
            return await _context.TestModels
                .FirstOrDefaultAsync(x => x.Id == testVM.Id);
        }
        public Test GetTestById(TestViewModel testVM)
        {
            return _context.TestModels
                .FirstOrDefault(x => x.Id == testVM.Id);
        }
        public List<Test> GetTestCreaterAsync(string userName)
        {
            return _context.TestModels
                .Include(x => x.Question)
                .Include(x => x.Users)
                .Where(x => x.Creater.UserName == userName)
                .ToList();
        }


        public void AddQuestionToTest(List<Question> questions, Test tests)
        {
            tests.Question.AddRange(questions);
        }
        public void DeleteQuestionToTest(List<Question> questions, Test test)
        {
           var orgTest= _context.TestModels.Include(x=>x.Question).FirstOrDefault(x => x.Id == test.Id);
            questions.ForEach(x =>
            {
                foreach (var y in orgTest.Question)
                {
                    if (y.Id == x.Id)
                    {
                        orgTest.Question.Remove(y);
                        break;
                    }
                }
            });
            _context.Update(orgTest);
        }
        public List<ExamResult> ExamResults(TestViewModel test,AppUser curUser)
        {
            var examResults = _context.ExamResults.Include(x=>x.Student).Include(x=>x.Exam)
                .Where(x => x.Exam.Id == test.Id && x.Exam.Creater.Id == curUser.Id)
                .ToList();
            return examResults;
    }

    }
}
