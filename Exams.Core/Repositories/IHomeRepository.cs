using Exams.Core.Models;

namespace Exams.Core.Repositories
{
    public interface IHomeRepository
    {
        public AppUser User(string name);
        public Task<int> CreatedTest(AppUser user);
        public Task<int> QuestionsCount(AppUser user);
        public Task<int> ExamsCount(AppUser user);
        public Task<int> ConnectionsCount(AppUser user);
    }
}
