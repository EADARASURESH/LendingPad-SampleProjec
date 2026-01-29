using System.Linq;
using BusinessEntities;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace Data.Indexes
{
    public class ExamsListIndex : AbstractIndexCreationTask<Exam>
    {
        public ExamsListIndex()
        {
            Map = exams => from exam in exams
                          select new
                                 {
                                     exam.Title,
                                     exam.Description,
                                     exam.DurationMinutes,
                                     exam.MaxScore
                                 };

            Index(x => x.Title, FieldIndexing.Analyzed);
        }
    }
}
