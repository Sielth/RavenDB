using Raven.Client.Documents;
using RavenDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RavenDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var documentStore = DocumentStoreHolder.Store)
            {
                using (var session = documentStore.OpenSession())
                {
                    // Examples from Per.
                    // Load or Query RavenDB.
                    Employee employee = session.Load<Employee>("employees/1-A");
                    List<Employee> employees = session.Query<Employee>().Where(e => e.FirstName == employee.FirstName).ToList();

                    // Change the name 

                    Console.WriteLine("Hello world!");
                }
            }
        }
    }
}
