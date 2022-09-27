using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Exams.Core.Services;
using Mapster;
using Microsoft.AspNetCore.Identity;

namespace Exams.Service.Services
{
    public class SignUpService : ISignUpService
    {
        private readonly ISignUpRepository _signUpRepository;

        public SignUpService(ISignUpRepository signUpRepository)
        {
            _signUpRepository = signUpRepository;
        }

        public async Task<CustomResponseDto<SignUpDTO>> SignUpAsync(SignUpDTO signUpDTO)
        {
            bool exist = await _signUpRepository.AnyAsync(x => x.UserName == signUpDTO.UserName);
            if (!exist)
            {
                AppUser user = signUpDTO.Adapt<AppUser>();
                user.ProfilePicture = "b446ff7c-733d-48b1-8be4-bab30bac7055_hitman.jpg";
                IdentityResult result = await _signUpRepository.CreateAsync(user, signUpDTO.Password);
               
                if(result.Succeeded)
                {

                    await _signUpRepository.AddRoleAsync(user,"User");
                }
                else
                {
                    List<string> Error = new List<string>();

                    result.Errors.ToList().ForEach(x => Error.Add(x.Description));
                    if(Error.Count > 0)
                    {
                    return CustomResponseDto<SignUpDTO>.Fail(403,Error);
                    }
                    else
                    {
                        return CustomResponseDto<SignUpDTO>.Fail(503, "Server'a ulaşılamıyor.");
                    }
                }
                return CustomResponseDto<SignUpDTO>.Success(201, signUpDTO);
            }
            else
            {
                return CustomResponseDto<SignUpDTO>.Fail(403, "Kullanıcı adı veya mail kullanılıyor");
            }
        }


    }
}
