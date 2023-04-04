using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ApplicationUserBooks = new HashSet<ApplicationUserBook>();
        }

        public ICollection<ApplicationUserBook> ApplicationUserBooks { get; set; }
    }
}
