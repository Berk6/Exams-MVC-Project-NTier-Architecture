namespace Exams.Core.DTOs
{
    public class UserViewModel
    {
        public string? UserName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string?  Search { get; set; }
        public bool isAdded { get; set; }
        public string? questId { get; set; }
        public string? ProfilePicture { get; set; }
        public string? Email { get; set; }
        public string? Institution { get; set; }
        public string? Education { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Explanation { get; set; }
        public string? Page { get; set; }
    }
}
