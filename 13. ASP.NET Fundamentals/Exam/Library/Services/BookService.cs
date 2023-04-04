using Library.Data;
using Library.Data.Models;
using Library.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Library.Services
{
    public class BookService
    {
        private LibraryDbContext context;
        public BookService(LibraryDbContext _context)
        {
            context = _context;
        }

        public async Task<ICollection<BookViewModel>> GetAll()
        {
            var books = await context.Books
                .Select(b => new BookViewModel()
                {
                    Id = b.Id,
                    CategoryId = b.CategoryId,
                    Author = b.Author,
                    Title = b.Title,
                    Category = b.Category,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating
                })
                .ToListAsync();

            return books.AsReadOnly();
        }

        public async Task<ICollection<BookViewModel>> GetUsersBooks(string id)
        {
            var books = await context.ApplicationUserBooks
                .Where(u => u.ApplicationUserId == id)
                .Select(u => u.Book)
                .ToListAsync();

            var bookViewModels = new List<BookViewModel>();

            foreach (var b in books)
            {
                bookViewModels.Add(new BookViewModel
                {
                    Id = b.Id,
                    CategoryId = b.CategoryId,
                    Author = b.Author,
                    Title = b.Title,
                    Description = b.Description,
                    Category = b.Category,
                    Rating = b.Rating,
                    ImageUrl = b.ImageUrl
                });
            }
            return bookViewModels.AsReadOnly();
        }


        public async Task Add(BookViewModel book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                CategoryId = book.CategoryId,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                Rating = book.Rating
            };

            await context.AddAsync(newBook);
            await context.SaveChangesAsync();
        }

        public async Task<ICollection<CategoryViewModel>> GetBookCategories()
        {
            var categories = await context.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();

            return categories.AsReadOnly();
        }

        public async Task AddBookToUser(int bookId, string userId)
        {
            await context.ApplicationUserBooks
                .AddAsync(new ApplicationUserBook()
                {
                    BookId = bookId,
                    ApplicationUserId = userId
                });

            await context.SaveChangesAsync();

        }

        public async Task RemoveBookFromUser(int bookId, string userId)
        {
            ApplicationUserBook applicationUserBookEntity = await context.ApplicationUserBooks
                .Where(ab => ab.BookId == bookId && ab.ApplicationUserId == userId)
                .FirstOrDefaultAsync();

            context.ApplicationUserBooks
                .Remove(applicationUserBookEntity);

            await context.SaveChangesAsync();
        }

    }
}
