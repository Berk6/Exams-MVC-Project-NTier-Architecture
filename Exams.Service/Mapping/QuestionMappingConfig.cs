using Exams.Core.DTOs;
using Exams.Core.Models;
using Mapster;

namespace Exams.Service.Mapping
{
    public class QuestionMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<QuestionViewModel, Question>().IgnoreNullValues(true);
            config.NewConfig<List<QuestionViewModel>,List<Question>>().IgnoreNullValues(true);
            config.NewConfig<List<Question>,List<QuestionViewModel>>().IgnoreNullValues(true);
            config.NewConfig<Question, QuestionViewModel>().IgnoreNullValues(true);
        }
    }
}
