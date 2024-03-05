using NikitaBookStore.Data;
using NikitaBookStore.Models;
using NikitaBookStore.Repository.IRepository;

namespace NikitaBookStore.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
            _context.Categories.Add(category);
        }
    }
}
