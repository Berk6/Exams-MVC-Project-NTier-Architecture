using Exams.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exams.Core.Models
{
    public class AppUser:IdentityUser
    {
        public AppUser()
        {
            MainUser = new List<AppUser>();
            UserConnection = new List<AppUser>();
        }
        public ICollection<Question> Questions { get; set; }
        [InverseProperty(nameof(Test.Creater))]
        public ICollection<Test> Tests { get; set; }
        [InverseProperty(nameof(Test.Users))]
        public ICollection<Test> Exams { get; set; }

        public ICollection<AppUser> MainUser { get; set; } 
        public ICollection<AppUser> UserConnection { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Address { get; set; }
        public string? Institution { get; set; }
        public EducationStatus? Education { get; set; }
        public Gender Gender { get; set; }
        public Country? Country { get; set; }
        public string? City { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Explanation { get; set; }
        public string? ProfilePicture { get; set; }

    }
}
