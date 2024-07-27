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
    public class CreateBookCommandValidatorTests : IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("Lord Of The Rings", 0, 0)]
        [InlineData("Lord Of The Rings", 0, 1)]
        [InlineData("Lord Of The Rings", 100, 0)]
        [InlineData("", 0, 0)]
        [InlineData("", 100, 1)]
        [InlineData("", 0, 1)]
        [InlineData("Lor", 100, 1)]
        [InlineData("Lord", 100, 0)]
        [InlineData("Lord", 0, 1)]
        [InlineData(" ", 100, 1)]
        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnErrors(string title, int pageCount, int genreId)
        {
            // Arrange
            CreateBook command = new CreateBook(null, null);
            command.Model = new CreateBookModel()
            {
                Title = title,
                PageCount = pageCount,
                PublishDate = DateTime.Now.Date.AddYears(-1),
                GenreId = genreId
            };

            // Act
            CreateBookValidator validator = new CreateBookValidator();
            var res = validator.Validate(command);

            // Assert
            res.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
