using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Exams.Core.Services;
using Exams.Core.UnitOfWorks;
using Mapster;
using MapsterMapper;

namespace Exams.Service.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public  List<QuestionViewModel> AllQuestions(UserViewModel user)
        {
           var allQuestion= _questionRepository.Where(x => x.Creater.UserName == user.UserName).ToList();
            List<QuestionViewModel> questionMaker = allQuestion.Adapt<List<QuestionViewModel>>();
            return questionMaker;
        }

        public async Task DeleteQuestion(List<QuestionViewModel> questionViewModels)
        {
            List<Question> question = new();
            questionViewModels.ForEach(x =>
            {
                if (x.check == true)
                {
                    question.Add(x.Adapt<Question>());
                }
            });
            _questionRepository.RemoveRange(question);
            await _unitOfWork.CommitAsync();
        }

        public async Task QuestionMaker(QuestionViewModel questionVM)
        {
            Question question = questionVM.Adapt<Question>();
            question.Creater= _questionRepository.Creater(questionVM.Creater);
            await _questionRepository.AddAsync(question);
            await _unitOfWork.CommitAsync();
        }

        public  async Task UpdateQuestion(QuestionViewModel questionVM)
        {
            var quest = await  _questionRepository.FirstOrDefaultAsync(questionVM.Id);
            _mapper.Map(questionVM, quest);
            //quest = _mapper.Map<Question>(questionVM);
            _questionRepository.Update(quest);
           await _unitOfWork.CommitAsync();
        }
    }
}
