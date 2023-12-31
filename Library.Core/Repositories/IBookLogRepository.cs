using Library.Core.Models;

namespace Library.Core.Repositories
{
    public interface IBookLogRepository : IGenericRepository<BookLog>
    {
        Task<List<BookLog>> GetBookLogs(int id);
    }
}
