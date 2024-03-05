using NikitaBookStore.Models;

namespace NikitaBookStore.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
    }
}
