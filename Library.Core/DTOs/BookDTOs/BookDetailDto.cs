namespace Library.Core.DTOs.BookDTOs
{
    public class BookDetailDto
    {
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? ImageUrl { get; set; }
        public bool inLibrary { get; set; }
        public List<BookLogDto>? Logs { get; set; }
    }
}
