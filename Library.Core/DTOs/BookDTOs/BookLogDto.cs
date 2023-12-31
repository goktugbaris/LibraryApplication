using Library.Core.Enums;

namespace Library.Core.DTOs.BookDTOs
{
    public class BookLogDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public BookLogTypes Action { get; set; }
    }
}
