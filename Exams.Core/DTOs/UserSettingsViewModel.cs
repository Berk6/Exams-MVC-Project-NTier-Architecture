using Exams.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Exams.Core.DTOs
{
    public class UserSettingsViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Surname { get; set; }
        public string? UserName { get; set; }
        public string? Address { get; set; }
        public string? Institution { get; set; }
        public EducationStatus Education { get; set; }
        public Country Country { get; set; }
        public Gender Gender { get; set; }
        public string? City { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        public string? Explanation { get; set; }
        public IFormFile? ProfileImage { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
