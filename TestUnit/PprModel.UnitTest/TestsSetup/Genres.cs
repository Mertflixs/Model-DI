using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.Entity;
using Ppr_Model.DBOperations;

namespace PprModel.UnitTest.TestsSetup
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Personal Growth"
                    },
                    new Genre
                    {
                        Name = "Fiction"
                    },
                    new Genre
                    {
                        Name = "Roman"
                    }
                );
        }
    }
}