using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.Common;
using AutoMapper;

namespace Ppr_Model.Application.GenreOperations.Queries.GetGenre
{
    public class GetGenreQuery
    {
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;
        
        public GetGenreQuery(BookStoreDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<GenresViewModel> Handle() {
            var genres = _context.Genres.Where(x => x.isActive).OrderBy(x => x.Id);
            List<GenresViewModel> returnObj = _mapper.Map<List<GenresViewModel>>(genres);

            return returnObj;
        }
        
    }

    public class GenresViewModel {
        public int Id {get; set;}
        public string Name {get; set;}
    }
}