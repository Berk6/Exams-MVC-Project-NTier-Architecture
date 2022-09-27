using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.Core.Services
{
    public interface IConnectionService
    {
        public (List<UserViewModel>, PagingViewModel) GetAllConnection(AppUser user, int pg);
        public (List<UserViewModel>, PagingViewModel) FindConnection(string name, AppUser curUser, int pg = 1);
        public  Task<CustomResponseDto<UserViewModel>> AddConnection(UserViewModel model, AppUser currentUser);
        public  Task<CustomResponseDto<UserViewModel>> RemoveConnection(UserViewModel model, AppUser currentUser);
    }
}
