using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.Entity;
using Ppr_Model.DBOperations;

namespace PprModel.UnitTest.TestsSetup
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
            context.Books.AddRange(
                new Book
                {
                    Id = 1,
                    Title = "Lean Zort",
                    GenreId = 1,
                    PageCount = 100,
                    PublishDate = new DateTime(2000, 07, 17)
                },
                new Book
                {
                    Id = 2,
                    Title = "Lean Kooko",
                    GenreId = 2,
                    PageCount = 190,
                    PublishDate = new DateTime(2010, 05, 22)
                },
                new Book
                {
                    Id = 3,
                    Title = "Lean Dune",
                    GenreId = 3,
                    PageCount = 190,
                    PublishDate = new DateTime(1999, 12, 13)
                }
            );
        }
    }
}