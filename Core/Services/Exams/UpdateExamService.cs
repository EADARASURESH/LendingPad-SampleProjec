using BusinessEntities;
using Common;

namespace Core.Services.Exams
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class UpdateExamService : IUpdateExamService
    {
        public void Update(Exam exam, string title, string description, int durationMinutes, int maxScore)
        {
            exam.SetTitle(title);
            exam.SetDescription(description);
            exam.SetDurationMinutes(durationMinutes);
            exam.SetMaxScore(maxScore);
        }
    }
}
