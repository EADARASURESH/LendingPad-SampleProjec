using BusinessEntities;

namespace WebApi.Models.Exams
{
    public class ExamData : IdObjectData
    {
        public ExamData(Exam exam) : base(exam)
        {
            Title = exam.Title;
            Description = exam.Description;
            DurationMinutes = exam.DurationMinutes;
            MaxScore = exam.MaxScore;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int DurationMinutes { get; set; }
        public int MaxScore { get; set; }
    }
}
