using Exams.Core.DTOs;

namespace Exams.Core.Services
{
    public interface IHomeService
    {
        public Task<HomeIndexDTO> Home(string name);
    }
}
