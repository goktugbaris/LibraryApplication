using AutoMapper;
using Library.Core.Enums;
using Library.Core.DTOs.BookDTOs;
using Library.Core.DTOs.ResultDTOs;
using Library.Core.Models;
using Library.Core.Services;
using Library.Service.FileService;
using Library.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Library.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;
        private readonly IBookLogService _bookLogService;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public BookController(IBookService bookService,  ILogger<BookController> logger, IMapper mapper, IFileService fileService, IBookLogService bookLogService)
        {
            _bookService = bookService;
            _logger = logger;
            _mapper = mapper;
            _fileService = fileService;
            _bookLogService = bookLogService;
        }

        public IActionResult Index(int pageIndex = 1, int pageSize = 5)
        {
            try
            {
                // Bütün kitapları listelemek için veri tabanında çekip pager ekleniyor.
                var books = _bookService.GetAllBooksWithLogs();
                var count = books.Count();

                var items = books
                    .OrderBy(x => x.Name)
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                var paginatedList = new PaginatedList<Book>(items, count, pageIndex, pageSize);

                var viewModel = new BookListViewModel
                {
                    PaginatedBooks = paginatedList
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting books.");
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookCreateDto postModel)
        {
            // Yeni bir kitap eklemek için gelen modeli db'ye model doğru ise kaydetiyoruz.
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(postModel);

                if(postModel.BookImage != null)
                {
                    var image = await _fileService.WriteFile(postModel.BookImage);
                    book.ImageUrl = image.pathName;
                }

                await _bookService.AddAsync(book);

                return RedirectToAction("Index");
            }

            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            TempData["ErrorMessages"] = errors;

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetDetail(int id)
        {
            try
            {
                // Kitabın detaylarını görmek istediğimiz zaman kullanıyoruz.
                var book = await _bookService.GetBookDetails(id);
                return View(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting book detail.");
                throw;
            }
        }

        public async Task<IActionResult> LendABookView(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            return View(book);
        }


        [HttpPost]
        public async Task<IActionResult> LendABook(BookLogDto postModel)
        {
            // Kitap ödünç alınmak istendiğinde modelden gelen verileri ekleyip kitap için log oluşturuyoruz.
            var book = await _bookService.GetByIdAsync(postModel.BookId);
            var bookLog = new BookLog()
            {
                BookId = postModel.BookId,
                Action = BookLogTypes.OnLoan,
                FirstName = postModel.FirstName,
                LastName = postModel.LastName,
                LogDate = DateTime.UtcNow,
            };

            book.BorrowDate = DateTime.UtcNow;
            book.inLibrary = false;
            book.ReturnedDate = postModel.CreatedOn.ToUniversalTime();

            await _bookService.UpdateAsync(book);

            var booklog = await _bookLogService.AddAsync(bookLog);
            return RedirectToAction("Index");
        }
    }
}
