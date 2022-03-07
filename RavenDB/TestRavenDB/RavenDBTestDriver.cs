using Raven.Client.Documents;
using Raven.TestDriver;
using System.Linq;
using Xunit;

namespace TestRavenDB
{
    public class RavenDBTestDriver : RavenTestDriver
    {
        // This allows us to modify the conventions of the store we get from 'GetDocumentStore'.
        protected override void PreInitialize(IDocumentStore documentStore)
        {
            documentStore.Conventions.MaxNumberOfRequestsPerSession = 50;
        }

        [Fact]
        public void Test()
        {
            using (var store = GetDocumentStore())
            {
                store.ExecuteIndex(new TestDocumentByName());

                using (var session = store.OpenSession())
                {
                    session.Store(new TestDocument { Name = "Hello world!" });
                    session.Store(new TestDocument { Name = "Goodbye..." });
                    session.SaveChanges();
                }

                WaitForIndexing(store); // If we want to query documents sometime we need to wait for the indexes to catch up.
                WaitForUserToContinueTheTest(store); // //Sometimes we want to debug the test itself, this redirect us to the studio.

                using (var session = store.OpenSession())
                {
                    var query = session.Query<TestDocument, TestDocumentByName>().Where(x => x.Name == "hello").ToList();
                    Assert.Single(query);
                }
            }
        }

    }
}
