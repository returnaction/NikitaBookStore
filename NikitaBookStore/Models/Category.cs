using System.ComponentModel.DataAnnotations;

namespace NikitaBookStore.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The max length of the title is 50 characters")]
        public string Title { get; set; } = null!;
        [MaxLength(1000, ErrorMessage = "The max number of the Display Order is 1000")]
        public int DisplayOrder { get; set; }
        
        // maybe later add list of categories
    }
}
