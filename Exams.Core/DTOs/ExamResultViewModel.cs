namespace Exams.Core.DTOs
{
    public class ExamResultViewModel
    {
        public int Id { get; set; }
        public TestViewModel Exam { get; set; }
        public float Result { get; set; }
        public UserViewModel Student { get; set; }
    }
}
