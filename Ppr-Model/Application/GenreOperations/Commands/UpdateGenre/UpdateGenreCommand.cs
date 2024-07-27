using System;
using System.Linq;
using Ppr_Model.DBOperations;

namespace Ppr_Model.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model { get; set; }

        private readonly IBookStoreDbContext _context;

        // Constructor
        public UpdateGenreCommand(IBookStoreDbContext context, int id)
        {
            _context = context;
            GenreId = id;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Id == GenreId);

            if (genre is null)
                throw new InvalidOperationException("Book not found!");

            if (_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.Id != GenreId))
                throw new InvalidOperationException("Book name already exists");

            genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
            genre.isActive = Model.isActive;
            _context.SaveChanges();
        }
    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool isActive { get; set; }
    }
}
