using Library.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class LibraryContext : DbContext
    {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookLog> BookLogs { get; set; }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedOn = DateTime.UtcNow;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedOn = DateTime.UtcNow;
                                break;
                            }
                    }
                }
            }
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedOn = DateTime.UtcNow;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedOn).IsModified = false;

                                entityReference.UpdatedOn = DateTime.UtcNow;
                                break;
                            }
                    }
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Book>()
                .HasMany(book => book.BookLogs)
                .WithOne(bookLog => bookLog.Book)
                .HasForeignKey(bookLog => bookLog.BookId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
