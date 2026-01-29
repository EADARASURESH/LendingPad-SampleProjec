using System;
using BusinessEntities;

namespace Core.Services.Exams
{
    public interface ICreateExamService
    {
        Exam Create(Guid id, string title, string description, int durationMinutes, int maxScore);
    }
}
