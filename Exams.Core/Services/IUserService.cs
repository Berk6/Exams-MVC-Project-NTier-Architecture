using Exams.Core.DTOs;
using Exams.Core.Models;

namespace Exams.Core.Services
{
    public interface IUserService
    {
        public void Settings(UserSettingsViewModel model, AppUser curUser);
        public UserViewModel ViewProfile(string userName, AppUser curUser);
    }
}
