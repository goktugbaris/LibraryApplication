using System.ComponentModel.DataAnnotations;

namespace Library.Core.Models
{
    public class Book : BaseEntity
    {
        [Display(Name = "Book Title")]
        [Required]
        public string? Name { get; set; }

        [Display(Name = "Book Author")]
        public string? Author { get; set; }

        [Display(Name = "Book Image")]
        public string? ImageUrl { get; set; }

        [Display(Name = "Book in Library")]
        public bool inLibrary { get; set; }

        public DateTime? BorrowDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        public virtual ICollection<BookLog>? BookLogs { get; set; }
    }
}
