using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ppr_Model.Application.BookOperations.CreateBook;
using Ppr_Model.Entity;
using Ppr_Model.Application.BookOperations.GetById;
using Ppr_Model.Application.BookOperations.GetBooks;
using Ppr_Model.Application.GenreOperations.Queries.GetGenre;
using Ppr_Model.Application.GenreOperations.Queries.GetGenreDetail;


namespace Ppr_Model.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel, Book>();
            CreateMap<Book, BookViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
            CreateMap<Book, BooksViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));

            CreateMap<Genre, GenresViewModel>();
            CreateMap<Genre, GenreDetailViewModel>();
        }
    }
}