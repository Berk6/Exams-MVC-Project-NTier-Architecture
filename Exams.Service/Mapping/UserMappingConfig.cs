using Exams.Core.DTOs;
using Exams.Core.Models;
using Mapster;

namespace Exams.Service.Mapping
{
    public class UserMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<UserSettingsViewModel, AppUser>().IgnoreNullValues(true);
        }
    }
}
