using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.DBOperations;
using Ppr_Model.Application.GenreOperations.Commands.CreateGenre;
using Ppr_Model.Application.GenreOperations.Commands.DeleteGenre;
using Ppr_Model.Application.GenreOperations.Commands.UpdateGenre;
using Ppr_Model.Application.GenreOperations.Queries.GetGenre;
using Ppr_Model.Application.GenreOperations.Queries.GetGenreDetail;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

namespace Ppr_Model.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenreQuery query = new GetGenreQuery(_context, _mapper);
            var res = query.Handle();
            return Ok(res);
        }

        [HttpGet("id")]
        public ActionResult GetGenresDetail(int id)
        {
            GetGenreDetailQuery query = new GetGenreDetailQuery(_context, _mapper, id);
            GetGenreDetailQueryValidator validator = new GetGenreDetailQueryValidator();

            validator.ValidateAndThrow(query);
            var res = query.Handle();

            return Ok(res);
        }

        [HttpPost]
        public ActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommand command = new CreateGenreCommand(_context);
            command.Model = newGenre;
            CreateGenreCommandValidator validator = new CreateGenreCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("id")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommand command = new UpdateGenreCommand(_context, id);
            command.Model = updateGenre;
            UpdateGenreCommandValidator validator = new UpdateGenreCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand command = new DeleteGenreCommand(_context, id);
            DeleteGenreCommandValidator validator = new DeleteGenreCommandValidator();

            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }
    }
}