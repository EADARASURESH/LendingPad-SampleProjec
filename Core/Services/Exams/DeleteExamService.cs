using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Exams
{
    [AutoRegister]
    public class DeleteExamService : IDeleteExamService
    {
        private readonly IExamRepository _examRepository;

        public DeleteExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public void Delete(Exam exam)
        {
            _examRepository.Delete(exam);
        }

        public void DeleteAll()
        {
            _examRepository.DeleteAll();
        }
    }
}
