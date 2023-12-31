using Library.Core.DTOs.BookDTOs;
using Library.Core.Models;

namespace Library.Core.Services
{
    public interface IBookService : IService<Book>
    {
        Task<BookDetailDto> GetBookDetails(int id);
        IQueryable<Book> GetAllBooksWithLogs();
    }
}
