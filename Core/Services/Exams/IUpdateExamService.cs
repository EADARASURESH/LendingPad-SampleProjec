using BusinessEntities;

namespace Core.Services.Exams
{
    public interface IUpdateExamService
    {
        void Update(Exam exam, string title, string description, int durationMinutes, int maxScore);
    }
}
