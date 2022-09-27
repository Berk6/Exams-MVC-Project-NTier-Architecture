using Exams.Core.DTOs;

namespace Exams.Core.Services
{
    public interface ISignUpService
    {
        public Task<CustomResponseDto<SignUpDTO>> SignUpAsync(SignUpDTO signUpDTO);        
    }
}