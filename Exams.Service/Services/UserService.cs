using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Exams.Core.Services;
using Exams.Core.UnitOfWorks;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Hosting;

namespace Exams.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IWebHostEnvironment webHostEnvironment, IUserRepository userRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _webHostEnvironment = webHostEnvironment;
            _userRepository = userRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public string UploadedFile(UserSettingsViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images/users");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        public UserViewModel ViewProfile(string userName,AppUser curUser)
        {
            var selectedUser = _userRepository.FindUserByUserName(userName);
            var userIsAdded = _userRepository.UserIsAdded(curUser);
            var userViewModel = selectedUser.Adapt<UserViewModel>();
            foreach (var item in userIsAdded)
            {
                if (item == selectedUser)
                {
                    userViewModel.isAdded = true;
                    break;
                }
            }
            return userViewModel;
        }
        public void Settings(UserSettingsViewModel model, AppUser curUser)
        {
            //var model2 = Context.Users.FirstOrDefault(x => x.Id == CurrentUser.Id);
            _mapper.Map(model, curUser);
            string uniqueFileName = UploadedFile(model);
            if (uniqueFileName != null)
            {
                curUser.ProfilePicture = uniqueFileName;
            }
            _userRepository.UpdateUser(curUser);
            _unitOfWork.Commit();
        }
    }
}
