using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Exams.Core.Services;
using Exams.Core.UnitOfWorks;

namespace Exams.Service.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoginRepository _loginRepository;


        public LoginService(IUnitOfWork unitOfWork,  ILoginRepository loginRepository)
        {
            _unitOfWork = unitOfWork;
            _loginRepository = loginRepository;
        }
        public async Task<CustomResponseDto<LoginDTO>> LoginAsync(LoginDTO loginDTO)
        {
            AppUser user = await _loginRepository.FindByNameAsync(loginDTO.UserName);
            //AppUser user = await _userManager.FindByNameAsync(loginDTO.UserName);
            if (user != null)
            {
                if (await _loginRepository.IsLockedOutAsync(user))
                {
                    return CustomResponseDto<LoginDTO>.Fail(403, "3 kez başarısız giriş yaptığınız için hesabınız geçici süreliğine kilitlenmiştir");
                }
                await _loginRepository.SignOutAsync();
                Microsoft.AspNetCore.Identity.SignInResult result = await _loginRepository.PasswordSignInAsync(user, loginDTO.Password, loginDTO.RememberMe, false);
                if (result.Succeeded)
                {
                    return CustomResponseDto<LoginDTO>.Success(200,loginDTO);
                }
                else
                {
                    await _loginRepository.GetAccessFailedCountAsync(user);
                    return CustomResponseDto<LoginDTO>.Fail(404, "Şifre veya Username Hatalı");
                }
            }
            else
            {
                return CustomResponseDto<LoginDTO>.Fail(404, "Kullanıcı Bulunamadı");
            }
        }

    }
}
