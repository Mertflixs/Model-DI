using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.Entity;
using Microsoft.EntityFrameworkCore;

namespace Ppr_Model.DBOperations
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Author> Author { get; set; }

        int SaveChanges();
    }
}
