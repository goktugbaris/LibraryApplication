using Library.Core.Models;

namespace Library.Core.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<Book> GetBookDetails(int id);
        IQueryable<Book> GetAllBooksWithLogs();
    }
}
