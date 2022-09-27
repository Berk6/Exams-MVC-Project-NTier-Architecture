using Exams.Core.DTOs;
using Exams.Core.Models;
using Exams.Core.Repositories;
using Exams.Core.Services;
using Exams.Core.UnitOfWorks;
using Mapster;

namespace Exams.Service.Services
{
    public class ConnectionService : Service<AppUser, UserViewModel>, IConnectionService
    {
        private readonly IConnectionRepository _connectionRepository;
        private readonly ILoginRepository _loginRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConnectionService(IConnectionRepository connectionRepository, IUnitOfWork unitOfWork, IRepository<AppUser> repository, ILoginRepository loginRepository) : base(unitOfWork, repository)
        {
            _connectionRepository = connectionRepository;
            _unitOfWork = unitOfWork;
            _loginRepository = loginRepository;
        }

        public (List<UserViewModel>, PagingViewModel) GetAllConnection(AppUser user, int pg)
        {
            var allConnection = _connectionRepository.GetAllConnection(user);
            var allConnectionVM = allConnection.Adapt<List<UserViewModel>>();
            const int pageSize = 5;
            if (pg < 1) pg = 1;
            int userCount = allConnectionVM.Count;
            var pager = new PagingViewModel(userCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = allConnectionVM.Skip(recSkip).Take(pager.PageSize).ToList();
            return (data, pager);
        }

        public (List<UserViewModel>, PagingViewModel) FindConnection(string name, AppUser curUser, int pg = 1)
        {
            List<AppUser> info = _connectionRepository.FindConnection(name);
            if (info == null)
            {
                return (null, null);
            }
            else
            {
                info.Remove(curUser);
                List<UserViewModel> userViewModel = info.Adapt<List<UserViewModel>>();
                List<AppUser> user = _connectionRepository.GetAllConnection(curUser);
                foreach (var allUser in userViewModel)
                {
                    foreach (var added in user)
                    {
                        if (allUser.UserName == added.UserName)
                        {
                            allUser.isAdded = true;
                            break;
                        }
                    }
                    allUser.Search = name;
                }
                const int pageSize = 5;
                if (pg < 1) pg = 1;
                int userCount = userViewModel.Count;
                var pager = new PagingViewModel(userCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = userViewModel.Skip(recSkip).Take(pager.PageSize).ToList();
                return (data, pager);
            }
        }
        public async Task<CustomResponseDto<UserViewModel>> AddConnection(UserViewModel model, AppUser currentUser)
        {
            var searchedUser = await _loginRepository.FindByNameAsync(model.UserName);
            var userIsAdded = _connectionRepository.GetAllConnection(currentUser);

            foreach (var addedUser in userIsAdded)
            {
                if (addedUser == searchedUser || searchedUser == currentUser)
                {
                    //return Redirect($"FindConnection/{model.Search}");
                    return CustomResponseDto<UserViewModel>.Fail(400, "Kullanıcı Daha Önceden EKlenmiş");
                }
            };
            currentUser.UserConnection.Add(searchedUser);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<UserViewModel>.Fail(204, "Ekleme İşlemi Gerçekleştirildi.");
        }
        public async Task<CustomResponseDto<UserViewModel>> RemoveConnection(UserViewModel model, AppUser currentUser)
        {
            var userIsAdded =await _connectionRepository.GetAllConnectionAnotherUser(model.UserName);
            if (userIsAdded != null)
            {
                currentUser.MainUser.Remove(userIsAdded);
                currentUser.UserConnection.Remove(userIsAdded);
                _connectionRepository.RemoveConnectionWithAllegiances(model, currentUser, userIsAdded);
                await _unitOfWork.CommitAsync();
                return CustomResponseDto<UserViewModel>.Fail(204, "Silme İşlemi Gerçekleştirildi.");
            }
            return  CustomResponseDto<UserViewModel>.Fail(404, "Kullanıcı Bulunamadı");
        }
    }
}
