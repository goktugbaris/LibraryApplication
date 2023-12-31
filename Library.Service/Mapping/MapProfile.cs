using AutoMapper;
using Library.Core.DTOs.BookDTOs;
using Library.Core.Models;

namespace Library.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, BookCreateDto>().ReverseMap();
            CreateMap<Book, BookDetailDto>()
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.BookLogs));
            CreateMap<BookDetailDto, Book>();


            CreateMap<BookLog, BookLogDto>().ReverseMap();
        }
    }
}
