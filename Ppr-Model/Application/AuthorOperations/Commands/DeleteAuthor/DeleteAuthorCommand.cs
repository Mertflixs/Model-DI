using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.Common;
using AutoMapper;

namespace Ppr_Model.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        public int AuthorId;

        private readonly BookStoreDbContext _context;

        public DeleteAuthorCommand(BookStoreDbContext context, int Id)
        {
            _context = context;
            AuthorId = Id;
        }

        public void Handle()
        {
            var author = _context.Author.SingleOrDefault(x => x.Id == AuthorId);

            if (author is null)
                throw new InvalidOperationException("Author not found!");

            _context.Author.Remove(author);
            _context.SaveChanges();
        }
    }
}