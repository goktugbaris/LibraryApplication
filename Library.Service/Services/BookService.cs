using AutoMapper;
using Library.Core.DTOs.BookDTOs;
using Library.Core.Models;
using Library.Core.Repositories;
using Library.Core.Services;
using Library.Core.UnitOfWorks;
using Library.Service.Exceptions;

namespace Library.Service.Services
{
    public class BookService : Service<Book> , IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> repository, IUnitOfWork unitOfWork, IMapper mapper, IBookRepository bookRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<BookDetailDto> GetBookDetails(int id)
        {
            var book = await _bookRepository.GetBookDetails(id);

            if (book == null)
                throw new NotFoundException("Book not found.");

            var dto = _mapper.Map<BookDetailDto>(book);
            return dto;
        }

        IQueryable<Book> IBookService.GetAllBooksWithLogs()
        {
            var books = _bookRepository.GetAllBooksWithLogs();
            return books;
        }
    }
}
