using AutoMapper;
using Library.Core.DTOs.BookDTOs;
using Library.Core.Models;
using Library.Core.Repositories;
using Library.Core.Services;
using Library.Core.UnitOfWorks;

namespace Library.Service.Services
{
    public class BookLogService : Service<BookLog>, IBookLogService
    {
        private readonly IBookLogRepository _bookLogRepository;
        private readonly IMapper _mapper;

        public BookLogService(IGenericRepository<BookLog> repository, IUnitOfWork unitOfWork, IMapper mapper, IBookLogRepository bookLogRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _bookLogRepository = bookLogRepository;
        }

        public async Task<List<BookLogDto>> GetBookLogs(int id)
        {
            var bookLogs = await _bookLogRepository.GetBookLogs(id);

            var dto = _mapper.Map<List<BookLogDto>>(bookLogs);
            return dto;
        }
    }
}
