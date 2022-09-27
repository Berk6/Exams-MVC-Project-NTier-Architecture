using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Exams.Core.Services;
using Exams.Core.UnitOfWorks;
using Mapster;
using MapsterMapper;

namespace Exams.Service.Services
{
    public class TestService : Service<Test, TestViewModel>, ITestService
    {
        private readonly ITestRepository _testRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IConnectionRepository _connectionRepository;
        private readonly IMapper _mapper;

        public TestService(IRepository<Test> repository, ITestRepository testRepository, IQuestionRepository questionRepository, IUnitOfWork unitOfWork, IMapper mapper, IConnectionRepository connectionRepository) : base(unitOfWork, repository)
        {
            _testRepository = testRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
            _connectionRepository = connectionRepository;
        }

        public async Task AddStudents(List<UserViewModel> userVMs, int testId)
        {
            if (userVMs.AsEnumerable().Any() && testId > 0)
            {
                Test test = await _testRepository.GetTestWithAllColumnByIdAsync(testId);
                List<UserViewModel> users = new();
                userVMs.ForEach(VM =>
                {
                    int count = 0;
                    test.Users.ForEach(user =>
                    {
                        if (VM.UserName == user.UserName)
                        {
                            count = 1;
                            
                        }
                    });
                    if (count == 0)
                    {
                        users.Add(VM);
                    }
                });

                _testRepository.AddStudentsToTest(users.Adapt<List<AppUser>>(), test);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteStudents(List<UserViewModel> userVMs, int testId)
        {
            if (userVMs.AsEnumerable().Any() && testId > 0)
            {
                Test test = await _testRepository.GetTestWithAllColumnByIdAsync(testId);
                List<AppUser> users = new();
                userVMs.ForEach(VM =>
                {
                    int count = 0;
                    test.Users.ForEach(user =>
                    {
                        if (VM.UserName == user.UserName)
                        {
                            count = 1;
                        }
                    });
                    if (count == 1)
                    {
                        users.Add(VM.Adapt<AppUser>());
                    }
                });
                _testRepository.DeleteStudentsToTest(users, test);
                await _unitOfWork.CommitAsync();
            }
        }
        public List<UserViewModel> GetAllConnection(AppUser user)
        {
            if (user != null)
            {
                var allUser = _connectionRepository.GetAllConnection(user);
                return allUser.Adapt<List<UserViewModel>>();
            }
            return null;
        }
        public async Task CreateTest(List<QuestionViewModel> quest, TestCreateViewModel test)
        {
            if (test.TestName != null)
            {
                Test orgTest = new();
                orgTest.Creater = test.Creater;
                orgTest.Name = test.TestName;
                foreach (var x in quest)
                {
                    if (x.check == true)
                    {
                        var quest2 = await _questionRepository.FirstOrDefaultAsync(x.Id);
                        orgTest.Question.Add(quest2);
                    }
                }
                await _testRepository.CreateTest(orgTest);
                await _unitOfWork.CommitAsync();
            }
        }
        public async Task DeleteTest(List<TestViewModel> testVM)
        {
            List<TestViewModel> tests = new();
            testVM.ForEach(testVM =>
            {
                if (testVM.check)
                {
                    tests.Add(testVM);
                }
            });
            if (tests != null)
            {
                var test = tests.Adapt<List<Test>>();
                _testRepository.DeleteTest(test);
                await _unitOfWork.CommitAsync();
            }
        }
        public async Task AddQuestionToTest(List<QuestionViewModel> questions, List<TestViewModel> testVM)
        {
            if (questions.AsEnumerable().Any() && testVM.AsEnumerable().Any())
            {
                List<Question> selectedQuests = new();
                foreach (var quest in questions)
                {
                    if (quest.check == true)
                    {
                        selectedQuests.Add(await _questionRepository.GetByIdAsync(quest.Id));
                    }
                }
                if (!selectedQuests.AsEnumerable().Any()) return;
                foreach (var test in testVM)
                {
                    if (test.check == true)
                    {
                        List<Question> nonExistingQuests = new();
                        var currentTest = await _testRepository.GetTestWithAllColumnByIdAsync(test.Id.Value);
                        foreach (var selectedQuest in selectedQuests)
                        {
                            int counter = 0;
                            foreach (var existQuest in currentTest.Question)
                            {
                                if (selectedQuest.Id == existQuest.Id)
                                {
                                    counter = 1;
                                    break;
                                }
                            }
                            if (counter == 0)
                            {
                                nonExistingQuests.Add(selectedQuest);
                            }
                        }
                        if (!nonExistingQuests.AsEnumerable().Any()) continue;

                        var t = await _testRepository.GetTestByIdAsync(test);
                        _testRepository.AddQuestionToTest(nonExistingQuests, t);
                    }
                }
                await _unitOfWork.CommitAsync();
            }
        }
        public async Task DeleteQuestionToTest(TestViewModel testVm)
        {
            if (testVm.Question.AsEnumerable().Any())
            {
                List<Question> selectedQuestion = new();
                testVm.Question.ForEach(quest =>
                {
                    if (quest.check)
                    {
                        selectedQuestion.Add(quest.Adapt<Question>());
                    }
                });
                _testRepository.DeleteQuestionToTest(selectedQuestion, testVm.Adapt<Test>());
                await _unitOfWork.CommitAsync();
            }
        }
        public List<TestViewModel> GetAllTestByCreater(string userName)
        {
            var tests = _testRepository.GetTestCreaterAsync(userName);
            List<TestViewModel> test = new();
            return _mapper.Map(tests, test);

        }
        public async Task TestNameChange(List<TestViewModel> testViewModels)
        {
            if (testViewModels[0].TestNewName != null)
            {

                List<Test> tests = new();
                testViewModels.ForEach(x =>
                {
                    if (x.check)
                    {
                        tests.Add(x.Adapt<Test>());
                    }
                });
                tests.ForEach(test =>
                {
                    test.Name = testViewModels[0].TestNewName;

                });
                _testRepository.UpdateRange(tests);
                await _unitOfWork.CommitAsync();
            }
        }

        public List<ExamResultViewModel> ExamResults(TestViewModel test, AppUser curUser)
        {
           var results= _testRepository.ExamResults(test, curUser);
            return results.Adapt<List<ExamResultViewModel>>();
        }
    }
}
