using Exams.Core.DTOs;

namespace Exams.Core.Services
{
    public interface IQuestionService
    {
        public Task QuestionMaker(QuestionViewModel questionMakerDTO);
        public List<QuestionViewModel> AllQuestions(UserViewModel user);
        public Task UpdateQuestion(QuestionViewModel questionMakerDTO);
        public Task DeleteQuestion(List<QuestionViewModel> questionViewModels);
    }
}
