using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister]
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        private readonly IDocumentSession _documentSession;

        public ExamRepository(IDocumentSession documentSession) : base(documentSession)
        {
            _documentSession = documentSession;
        }

        public IEnumerable<Exam> Get(string title = null)
        {
            var query = _documentSession.Advanced.DocumentQuery<Exam, ExamsListIndex>();

            if (title != null)
            {
                query = query.Where($"Title:*{title}*");
            }

            return query.ToList();
        }

        public void DeleteAll()
        {
            base.DeleteAll<ExamsListIndex>();
        }
    }
}
