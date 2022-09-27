using Exams.Core.Models;

namespace Exams.Core.DTOs
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        public string? Quest { get; set; }
        public string? Answer1 { get; set; }
        public string? Answer2 { get; set; }
        public string? Answer3 { get; set; }
        public string? Answer4 { get; set; }
        public string? Answer5 { get; set; }
        public string? TrueAnswer { get; set; }
        public UserViewModel? Creater { get; set; }
        public bool check { get; set; }
    }
}
