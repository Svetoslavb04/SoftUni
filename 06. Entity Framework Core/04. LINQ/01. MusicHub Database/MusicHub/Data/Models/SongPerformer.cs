using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicHub.Data.Models
{
    public class SongPerformer
    {
        public SongPerformer()
        {

        }

        [ForeignKey(nameof(Song))]
        public int SongId { get; set; }
        
        [Required]
        public virtual Song Song { get; set; }

        [ForeignKey(nameof(Performer))]
        public int PerformerId { get; set; }

        [Required]
        public virtual Performer Performer { get; set; }
    }
}