namespace Exams.Core.Models
{
    public class Question
    {
        public int Id { get; set; }
        public AppUser Creater { get; set; }
        public string Quest { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }
        public string Answer5 { get; set; }
        public string TrueAnswer {get; set;}
        public bool check { get; set; } 
        public List<Test>? Tests { get; set; } = new List<Test>();    
    }
}
