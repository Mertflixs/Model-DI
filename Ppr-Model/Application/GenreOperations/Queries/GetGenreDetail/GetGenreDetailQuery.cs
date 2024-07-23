using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.Common;
using AutoMapper;

namespace Ppr_Model.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQuery
    {
        public int _genreId;
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetGenreDetailQuery(BookStoreDbContext context, IMapper mapper, int genreId)
        {
            _context = context;
            _mapper = mapper;
            _genreId = genreId;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.isActive && x.Id == _genreId);

            if (genre is null)
                throw new InvalidOperationException("Not found Genre!");
            
            return _mapper.Map<GenreDetailViewModel>(genre);
        }

    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}