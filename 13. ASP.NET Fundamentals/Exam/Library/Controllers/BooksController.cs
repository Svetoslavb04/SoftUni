using Library.Data.Models;
using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private BookService bookService;
        private UserManager<ApplicationUser> userManager;
        public BooksController(BookService _bookService, UserManager<ApplicationUser> _userManager)
        {
            bookService = _bookService;
            userManager = _userManager;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await bookService.GetAll();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var usersBooks = await bookService.GetUsersBooks(userManager.GetUserId(User));

            return View(usersBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await bookService.GetBookCategories();

            AddBookViewModel model = new AddBookViewModel() { 
                Categories = categories
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            if(!ModelState.IsValid)
            {
                model.Categories = await bookService.GetBookCategories();

                return View(model);
            }

            BookViewModel book = new BookViewModel() { 
                Title = model.Title,
                Author= model.Author,
                CategoryId = model.CategoryId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                Rating = model.Rating
            };

            await bookService.Add(book);

            return Redirect("All");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                await bookService.AddBookToUser(bookId, userManager.GetUserId(User));
            }
            catch (Exception)
            {
            }

            return RedirectToAction("Mine");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            await bookService.RemoveBookFromUser(bookId, userManager.GetUserId(User));

            return RedirectToAction("Mine");
        }
    }
}
