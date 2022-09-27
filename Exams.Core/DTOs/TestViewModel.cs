using Exams.Core.Models;

namespace Exams.Core.DTOs
{
    public class TestViewModel
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public UserViewModel? Creater { get; set; } 
        public List<QuestionViewModel>? Question { get; set; } = new();
        public List<UserViewModel>? Users { get; set; } = new();
        public string? TestNewName { get; set; }
        public bool check { get; set; }
    }
}
