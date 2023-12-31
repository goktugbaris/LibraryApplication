using Library.Core.UnitOfWorks;
using System;

namespace Library.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryContext _context;
        public UnitOfWork(LibraryContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
