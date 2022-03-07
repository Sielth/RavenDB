using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRavenDB
{
    class TestDocumentByName : AbstractIndexCreationTask<TestDocument>
    {
        public TestDocumentByName()
        {
            Map = docs => from doc in docs select new { doc.Name };
            Indexes.Add(x => x.Name, FieldIndexing.Search);
        }
    }
}
