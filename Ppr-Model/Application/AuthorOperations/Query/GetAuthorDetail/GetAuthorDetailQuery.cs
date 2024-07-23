using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.Common;
using AutoMapper;

namespace Ppr_Model.Application.AuthorOperations.Query.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        public int _AuthorId;
        public readonly BookStoreDbContext _context;
        public readonly IMapper _mapper;

        public GetAuthorDetailQuery(BookStoreDbContext context, IMapper mapper, int AuthorId)
        {
            _context = context;
            _mapper = mapper;
            _AuthorId = AuthorId;
        }

        public AuthorDetailViewModel Handle() {
            var author = _context.Author.SingleOrDefault(x => x.Id == _AuthorId);

            if (author is null)
                throw new InvalidOperationException("Not found Author!");
            
            return _mapper.Map<AuthorDetailViewModel>(author);
        }
    }

    public class AuthorDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public DateTime Birthdate { get; set; }
    }
}