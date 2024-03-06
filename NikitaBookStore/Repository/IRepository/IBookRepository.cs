using NikitaBookStore.Models;

namespace NikitaBookStore.Repository.IRepository
{
    public interface IBookRepository : IRepository<Book>
    {
        void Update(Book book);
    }
}
