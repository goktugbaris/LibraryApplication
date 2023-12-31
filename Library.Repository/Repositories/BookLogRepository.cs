using Library.Core.Models;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository.Repositories
{
    public class BookLogRepository : GenericRepository<BookLog>, IBookLogRepository
    {
        public BookLogRepository(LibraryContext context) : base(context)
        {
        }

        public async Task<List<BookLog>> GetBookLogs(int id)
        {
            return await _context.BookLogs
                .Where(x => x.BookId == id)
                .ToListAsync();
        }
    }
}
