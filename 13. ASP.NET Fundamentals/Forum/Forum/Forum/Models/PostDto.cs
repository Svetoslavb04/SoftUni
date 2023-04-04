using System.ComponentModel.DataAnnotations;
using static Forum.Data.DataConstants.Post;

namespace Forum.Models
{
    public class PostDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleMaximumLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(ContentMaximumLength)]
        public string Content { get; set; }
    }
}
