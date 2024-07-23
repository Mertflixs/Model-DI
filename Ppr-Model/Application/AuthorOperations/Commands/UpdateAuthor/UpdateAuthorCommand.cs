using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.Common;
using AutoMapper;

namespace Ppr_Model.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public int AuthorId;
        public UpdateAuthorModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public UpdateAuthorCommand(BookStoreDbContext context, IMapper mapper, int id)
        {
            _context = context;
            _mapper = mapper;
            AuthorId = id;
        }

        public void Handle()
        {
            var author = _context.Author.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Author not found!");

            if (_context.Author.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Lastname.ToLower() == Model.Lastname.ToLower() && x.Id != AuthorId))
                throw new InvalidOperationException("Author Already exist!");
            _mapper.Map(Model, author);
            _context.SaveChanges();
        }
    }

    public class UpdateAuthorModel
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}