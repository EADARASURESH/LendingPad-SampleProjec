namespace WebApi.Models.Exams
{
    public class ExamModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; }
        public int MaxScore { get; set; }
    }
}
