using NikitaBookStore.Data;
using NikitaBookStore.Repository.IRepository;

namespace NikitaBookStore.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public ICategoryRepository Category { get; private set; }
        public IBookRepository Book { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(_context);
            Book = new BookRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
