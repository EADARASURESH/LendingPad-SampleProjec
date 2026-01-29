using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IExamRepository : IRepository<Exam>
    {
        IEnumerable<Exam> Get(string title = null);
        void DeleteAll();
    }
}
