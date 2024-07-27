using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ppr_Model.Entity;

namespace Ppr_Model.DBOperations
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Author> Author { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}