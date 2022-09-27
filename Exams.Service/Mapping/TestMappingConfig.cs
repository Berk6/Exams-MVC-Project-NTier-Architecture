using Exams.Core.DTOs;
using Exams.Core.Models;
using Mapster;

namespace Exams.Service.Mapping
{
    public class TestMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Test, TestViewModel>().IgnoreNullValues(true);
            config.NewConfig<TestViewModel, Test>().IgnoreNullValues(true);
            config.NewConfig<List<Test>, List<TestViewModel>>().IgnoreNullValues(true);
            config.NewConfig<List<TestViewModel>, List<Test>>().IgnoreNullValues(true);
        }
    }
}
