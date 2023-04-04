using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class CategoryViewModel
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
    }
}