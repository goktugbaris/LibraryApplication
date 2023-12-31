using Library.Core.Models;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        public BookRepository(LibraryContext context) : base(context)
        {
        }

        public IQueryable<Book> GetAllBooksWithLogs()
        {
            return _context.Books
                .Include(x => x.BookLogs)
                .AsNoTracking()
                .AsQueryable();
        }

        public async Task<Book> GetBookDetails(int id)
        {
            return await _context.Books
                .Include(x => x.BookLogs)
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();
        }
    }
}
