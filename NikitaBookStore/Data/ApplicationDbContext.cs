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
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Title = "Hummor", DisplayOrder = 2 },
                new Category { Id = 3, Title = "SciFi", DisplayOrder = 3 },
                new Category { Id = 4, Title = "History", DisplayOrder = 4 },
                new Category { Id = 5, Title = "Drama", DisplayOrder = 5 });

            builder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Fortune of Time",
                    Author = "Billy Spark",
                    Price = 90,
                    CategoryId = 1,
                    ImageURL = ""
                },
                new Book
                {
                    Id = 2,
                    Title = "Dark Skies",
                    Author = "Nancy Hoover",
                    Price = 30,
                    CategoryId = 2,
                    ImageURL = ""
                },
                new Book
                {
                    Id = 3,
                    Title = "Vanish in the Sunset",
                    Author = "Julian Button",
                    Price = 50,
                    CategoryId = 3,
                    ImageURL = ""
                },
                new Book
                {
                    Id = 4,
                    Title = "Cotton Candy",
                    Author = "Abby Muscles",
                    Price = 65,
                    CategoryId = 4,
                    ImageURL = ""
                },
                new Book
                {
                    Id = 5,
                    Title = "Rock in the Ocean",
                    Author = "Ron Parker",
                    Price = 27,
                    CategoryId = 5,
                    ImageURL = ""
                },
                new Book
                {
                    Id = 6,
                    Title = "Leaves and Wonders",
                    Author = "Laura Phantom",
                    Price = 23,
                    CategoryId = 1,
                    ImageURL = ""
                });
        }
    }
}
