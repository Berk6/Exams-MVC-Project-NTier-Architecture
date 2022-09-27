using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Exams.Core.Services;

namespace Exams.Service.Services
{
    public class HomeService : IHomeService
    {
        private readonly IHomeRepository _homeRepository;

        public HomeService(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }

        public async Task<HomeIndexDTO> Home(string name)
        {
            HomeIndexDTO homeIndexDTO = new HomeIndexDTO();
            AppUser appUser= _homeRepository.User(name);
            homeIndexDTO.ConnectionsCount= await _homeRepository.ConnectionsCount(appUser);
            homeIndexDTO.ExamsCount= await _homeRepository.ExamsCount(appUser);
            homeIndexDTO.CreatedTests = await _homeRepository.CreatedTest(appUser);
            homeIndexDTO.QuestionsCount= await _homeRepository.QuestionsCount(appUser);
            return  homeIndexDTO;
        }
    }
}
