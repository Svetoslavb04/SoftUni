using System.ComponentModel.DataAnnotations;
using static Forum.Data.DataConstants.Post;

namespace Forum.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaximumLength, MinimumLength = TitleMinimumLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ContentMaximumLength, MinimumLength = ContentMinimumLength)]
        public string Content { get; set; }
    }
}
