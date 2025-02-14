using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.DBOperations;
using Ppr_Model.Application.BookOperations.GetBooks;
using Ppr_Model.Application.BookOperations.CreateBook;
using Ppr_Model.Application.BookOperations.DeleteBook;
using Ppr_Model.Application.BookOperations.GetById;
using Ppr_Model.Application.BookOperations.UpdateBook;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

namespace Ppr_Model.Controllers
{
    [ApiController]
    [Route("[controller]s")]
    public class BookControllers : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookControllers(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("GetAllBooks")]
        public IActionResult GetBook()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var res = query.Handle();
            return Ok(res);
        }

        [HttpGet("GetBookId/{id}")]
        public IActionResult GetById(int id)
        {
            GetById query = new GetById(_context, id, _mapper);

            GetByIdValidator validator = new GetByIdValidator();
            validator.ValidateAndThrow(query);
            var res = query.Handle();
            return Ok(res);

        }

        //fromQuery ile 
        [HttpGet("GetBookQuery")]
        public Book GetByIdQuery([FromQuery] string id)
        {
            var book = _context.Books.Where(x => x.Id == Convert.ToInt32(id)).SingleOrDefault();
            return book;
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBook command = new CreateBook(_context, _mapper);

            command.Model = newBook;
            CreateBookValidator validator = new CreateBookValidator();
            validator.ValidateAndThrow(command);
            command.Handle();

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel newBook)
        {
            UpdateBook book = new UpdateBook(_context);

            book.Model = newBook;
            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(book);
            book.Handle(id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBook book = new DeleteBook(_context, id);

            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(book);
            book.Handle();

            return Ok();
        }
    }
}