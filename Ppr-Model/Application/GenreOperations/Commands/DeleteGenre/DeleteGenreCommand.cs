using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.Common;
using AutoMapper;

namespace Ppr_Model.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public int GenreId;
        private readonly BookStoreDbContext _context;

        public DeleteGenreCommand(BookStoreDbContext context, int Id)
        {
            _context = context;
            GenreId = Id;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("Book not found!");
            
            _context.Genres.Remove(genre);
            _context.SaveChanges();
        }
    }
}