using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.DBOperations;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Ppr_Model.Application.AuthorOperations.Commands.CreateAuthor;
using Ppr_Model.Application.AuthorOperations.Commands.DeleteAuthor;
using Ppr_Model.Application.AuthorOperations.Commands.UpdateAuthor;
using Ppr_Model.Application.AuthorOperations.Query.GetAuthor;
using Ppr_Model.Application.AuthorOperations.Query.GetAuthorDetail;

namespace Ppr_Model.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class AuthorControllers : ControllerBase
    {
        private BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public AuthorControllers(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult GetAuthors()
        {
            GetAuthorQuery query = new GetAuthorQuery(_context,
            _mapper);
            var res = query.Handle();
            return Ok(res);
        }

        [HttpGet("id")]
        public ActionResult GetAuthorDetail(int id)
        {
            GetAuthorDetailQuery query = new GetAuthorDetailQuery(_context, _mapper, id);
            GetAuthorDetailQueryValidator validator = new GetAuthorDetailQueryValidator();

            validator.ValidateAndThrow(query);
            var res = query.Handle();

            return Ok(res);
        }

        [HttpPost]
        public ActionResult AddAuthor([FromBody] CreateAuthorModel newAuthor)
        {
            CreateAuthorCommand command = new CreateAuthorCommand(_context, _mapper);
            command.Model = newAuthor;
            CreateAuthorCommandValidator validator = new CreateAuthorCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateAuthor(int id, [FromBody] UpdateAuthorModel updateAuthor) {
            UpdateAuthorCommand command = new UpdateAuthorCommand(_context, _mapper, id);
            command.Model = updateAuthor;
            UpdateAuthorCommandValidator validator = new UpdateAuthorCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteAuthor(int id) {
            DeleteAuthorCommand command = new DeleteAuthorCommand(_context, id);
            DeleteAuthorCommandValidator validator = new DeleteAuthorCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}