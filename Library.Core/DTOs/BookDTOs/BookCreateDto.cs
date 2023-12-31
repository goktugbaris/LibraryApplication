using Microsoft.AspNetCore.Http;

namespace Library.Core.DTOs.BookDTOs
{
    public class BookCreateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool inLibrary { get; set; }
        public IFormFile? BookImage { get; set; }
    }
}
