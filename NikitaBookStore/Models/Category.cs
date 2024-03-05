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

        [Range(1,100, ErrorMessage = "Range is between 1 and 100")]
        public int DisplayOrder { get; set; }
        
       
    }
}
