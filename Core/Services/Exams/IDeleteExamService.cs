using BusinessEntities;

namespace Core.Services.Exams
{
    public interface IDeleteExamService
    {
        void Delete(Exam exam);
        void DeleteAll();
    }
}
