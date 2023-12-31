using Library.Core.Enums;

namespace Library.Core.Models
{
    public class BookLog : BaseEntity
    {
        public int BookId { get; set; }
        public virtual Book Book { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime LogDate { get; set; }
        public BookLogTypes Action { get; set; }
    }
}
