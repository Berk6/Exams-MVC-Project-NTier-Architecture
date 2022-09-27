using System.ComponentModel.DataAnnotations.Schema;

namespace Exams.Core.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [InverseProperty(nameof(AppUser.Tests))]
        public AppUser Creater { get; set; }
        [InverseProperty(nameof(AppUser.Exams))]
        public List<AppUser>? Users { get; set; } = new();
        public List<Question>? Question { get; set; }=new List<Question>();     
        
    }
}
