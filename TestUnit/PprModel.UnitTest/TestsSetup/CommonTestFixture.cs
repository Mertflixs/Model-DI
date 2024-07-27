using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ppr_Model.Common;

namespace PprModel.UnitTest.TestsSetup
{
    public class CommonTestFixture
    {
        public BookStoreDbContext? Context { get; set; }
        public IMapper? Mapper { get; set; }

        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreDb").Options;
            Context = new BookStoreDbContext(options);

            Context.Database.EnsureCreated();
            Context.AddBooks();
            Context.AddGenres();
            Context.AddAuthors();

            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>(); }).CreateMapper();
        }
    }
}