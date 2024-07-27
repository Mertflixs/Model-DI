using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.Entity;
using Ppr_Model.DBOperations;

namespace PprModel.UnitTest.TestsSetup
{
    public static class Authors
    {
        public static void AddAuthors(this BookStoreDbContext context)
        {
            context.Author.AddRange(
                   new Author
                   {
                       Name = "Test1",
                       Lastname = "Test1",
                       Birthdate = new DateTime(1999, 12, 13)
                   },
                   new Author
                   {
                       Name = "Test2",
                       Lastname = "Test2",
                       Birthdate = new DateTime(1999, 12, 13)
                   },
                   new Author
                   {
                       Name = "Test3",
                       Lastname = "Test3",
                       Birthdate = new DateTime(1999, 12, 13)
                   },
                   new Author
                   {
                       Name = "Test4",
                       Lastname = "Test4",
                       Birthdate = new DateTime(1999, 12, 13)
                   }
               );
        }
    }
}