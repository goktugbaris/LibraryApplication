using Library.Core.Models;

namespace Library.Core.DTOs.BookDTOs
{
    public class BookDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public bool inLibrary { get; set; }
        public List<BookLog>? Logs { get; set; }
    }
}
