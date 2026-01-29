using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Exams
{
    [AutoRegister]
    public class GetExamService : IGetExamService
    {
        private readonly IExamRepository _examRepository;

        public GetExamService(IExamRepository examRepository)
        {
            _examRepository = examRepository;
        }

        public Exam GetExam(Guid id)
        {
            return _examRepository.Get(id);
        }

        public IEnumerable<Exam> GetExams(string title = null)
        {
            return _examRepository.Get(title);
        }
    }
}
