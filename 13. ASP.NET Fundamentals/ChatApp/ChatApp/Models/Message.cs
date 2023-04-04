using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models
{
    public class Message
    {
        [MinLength(1)]
        public string Text { get; set; }
    }
}
