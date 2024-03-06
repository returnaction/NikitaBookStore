using NikitaBookStore.Data;
using NikitaBookStore.Models;
using NikitaBookStore.Repository.IRepository;

namespace NikitaBookStore.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private ApplicationDbContext _context;
        public BookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
        }
    }
}
