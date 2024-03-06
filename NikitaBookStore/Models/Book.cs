using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.CodeAnalysis.Scripting.Hosting;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NikitaBookStore.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25, ErrorMessage = "Max lenth of the title is 25 characters")]
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(25, ErrorMessage = "Max lenth of the title is 25 characters")]
        public string Author { get; set; } = null!;


        public decimal Price { get; set; }
        public DateTime DatePublished { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ValidateNever]
        public int CategoryId { get; set; }

        [ValidateNever]
        public string?  ImageURL { get; set; }
    }
}
