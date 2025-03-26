using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace BusinessEntities
{
    public class UserIndex : AbstractIndexCreationTask<User>
    {
        public UserIndex()
        {
            Map = documents => from doc in documents
                               from tag in doc.Tags
                               select new
                               {
                                   tag
                               };

            // This stores the Name field as NotAnalyzed (case-sensitive)
            this.Store(x => x.Tags, FieldStorage.Yes);
        }
    }
}
