using Exams.Core.DTOs;

namespace Exams.Core.Services
{
    public interface ILoginService
    {
        public  Task<CustomResponseDto<LoginDTO>> LoginAsync(LoginDTO loginDTO);
    }
}
