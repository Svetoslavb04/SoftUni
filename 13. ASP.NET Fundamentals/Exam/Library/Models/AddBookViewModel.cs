using Library.Data.Models;

namespace Library.Models
{
    public class AddBookViewModel: BookViewModel
    {
        public ICollection<CategoryViewModel>? Categories { get; set; }
    }
}
