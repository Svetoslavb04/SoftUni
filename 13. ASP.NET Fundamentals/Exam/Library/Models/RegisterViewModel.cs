using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(60, MinimumLength = 10)]
        public string Email { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; } = null!;

        [Required]
        [PasswordPropertyText]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
