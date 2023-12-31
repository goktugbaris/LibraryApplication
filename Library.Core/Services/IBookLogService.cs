using Library.Core.DTOs.BookDTOs;
using Library.Core.Models;

namespace Library.Core.Services
{
    public interface IBookLogService : IService<BookLog>
    {
        Task<List<BookLogDto>> GetBookLogs(int id);
    }
}
