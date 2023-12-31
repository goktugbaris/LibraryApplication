using Library.Core.DTOs.ResultDTOs;
using Library.Core.Models;

namespace Library.Web.ViewModels
{
    public class BookListViewModel
    {
        public PaginatedList<Book> PaginatedBooks { get; set; }
        public int TotalPages => PaginatedBooks.TotalPages;
        public int PageIndex => PaginatedBooks.PageIndex;
        public int PageSize => PaginatedBooks.Count;
    }
}
