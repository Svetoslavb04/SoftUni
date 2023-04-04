using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; } = null!;
    }
}
