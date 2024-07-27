using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PprModel.UnitTest.TestsSetup;
using Xunit;
using Ppr_Model.DBOperations;
using Ppr_Model.Entity;
using AutoMapper;
using Ppr_Model.Application.BookOperations.CreateBook;
using FluentAssertions;

namespace PprModel.UnitTest.Application.BookOperations.Commands.CreateCommand
{
    public class CreateBookCommandTests : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            // Arrange (Hazırlık)
            var existingBook = _context.Books.SingleOrDefault(b => b.Title == "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn");
            var book = new Book()
            {
                Id = 999,
                Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn",
                PageCount = 100,
                PublishDate = new DateTime(1990, 01, 10),
                GenreId = 1
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            CreateBook command = new CreateBook(_context, _mapper);
            command.Model = new CreateBookModel()
            {
                Title = book.Title
            };

            // Act & Assert (Çalıştırma ve Doğrulama)
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>()
                .WithMessage("Mevcut");
        }
    }
}
