using System;
using BusinessEntities;
using Common;
using Core.Factories;
using Data.Repositories;

namespace Core.Services.Exams
{
    [AutoRegister]
    public class CreateExamService : ICreateExamService
    {
        private readonly IUpdateExamService _updateExamService;
        private readonly IIdObjectFactory<Exam> _examFactory;
        private readonly IExamRepository _examRepository;

        public CreateExamService(IIdObjectFactory<Exam> examFactory, IExamRepository examRepository, IUpdateExamService updateExamService)
        {
            _examFactory = examFactory;
            _examRepository = examRepository;
            _updateExamService = updateExamService;
        }

        public Exam Create(Guid id, string title, string description, int durationMinutes, int maxScore)
        {
            var exam = _examFactory.Create(id);
            _updateExamService.Update(exam, title, description, durationMinutes, maxScore);
            _examRepository.Save(exam);
            return exam;
        }
    }
}
