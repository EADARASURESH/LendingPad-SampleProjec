using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Exams
{
    public interface IGetExamService
    {
        Exam GetExam(Guid id);
        IEnumerable<Exam> GetExams(string title = null);
    }
}
