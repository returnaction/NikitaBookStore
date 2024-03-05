using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NikitaBookStore.Models;

namespace NikitaBookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Title = "Hummor", DisplayOrder = 2 },
                new Category { Id = 3, Title = "SciFi", DisplayOrder = 3 },
                new Category { Id = 4, Title = "History", DisplayOrder = 4 },
                new Category { Id = 5, Title = "Drama", DisplayOrder = 5 });

        }
    }
}
