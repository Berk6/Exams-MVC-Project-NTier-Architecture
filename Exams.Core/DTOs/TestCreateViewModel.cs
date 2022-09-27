using Exams.Core.Models;
namespace Exams.Core.DTOs
{
    public class TestCreateViewModel
    {
        public string? TestName { get; set; }
        public AppUser? Creater { get; set; } 
        public List<Question>? questions { get; set; }
        public List<AppUser>? Students { get; set; }
        public List<TestViewModel>? Tests { get; set; }=new List<TestViewModel>();

    }
}
