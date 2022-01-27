namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            var sb = new StringBuilder();

            var ageRestrictionInput = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestrictionInput)
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title).ToList()
                .ToList();

            books.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().Trim();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => ((int)b.EditionType) == 2 && b.Copies < 5000)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();
                
            books.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().Trim();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40)
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .ToList();

            books.ForEach(b => sb.AppendLine($"{b.Title} - ${b.Price:F2}"));

            return sb.ToString().Trim();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .Select(b => new
                {
                    b.Title,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            books.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.BooksCategories
                .Where(bc => input.ToLower().Split().ToList().Any(c => c == bc.Category.Name.ToLower()))
                .Select(bc => new
                {
                    bc.Book.Title
                })
                .OrderBy(b => b.Title)
                .ToList();
               
            books.ForEach((b) => sb.AppendLine($"{b.Title}"));

            return sb.ToString().Trim();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var sb = new StringBuilder();

            DateTime dateTime = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(x => x.ReleaseDate < dateTime)
                .Select(x => new { x.Title, x.EditionType, x.Price, x.ReleaseDate })
                .OrderByDescending(x => x.ReleaseDate);


            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .OrderBy(a => a.FullName)
                .ToList();

            authors.ForEach(a => sb.AppendLine(a.FullName));

            return sb.ToString().Trim();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(b => b.Title)
                .ToList();

            books.ForEach(b => sb.AppendLine(b.Title));

            return sb.ToString().Trim();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.Title,
                    AuthorFullName = $"{b.Author.FirstName} {b.Author.LastName}",
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .ToList();

            books.ForEach(books => sb.AppendLine($"{books.Title} ({books.AuthorFullName})"));

            return sb.ToString().Trim();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var count = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return count;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                ,
                    TotalCopies = a.Books.Sum(b => b.Copies)
                })
                .OrderByDescending(a => a.TotalCopies)
                .ToList();

            authors.ForEach(a => sb.AppendLine($"{a.FullName} - {a.TotalCopies}"));

            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var sb = new StringBuilder();
            
            var categoriesGroup = context.Categories
                .Select(b => new
                {
                    b.Name,
                    Profit = b.CategoryBooks.Select(bc => new
                    {
                        bc.Book.Copies, bc.Book.Price
                    }).Sum(bp => bp.Copies * bp.Price)
                }).OrderByDescending(x => x.Profit)
                .ThenBy(x => x.Name);

            foreach (var category in categoriesGroup)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:F2}");
            };

            return sb.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var sb = new StringBuilder();

            var categoriesGroup = context.Categories
                .Select(b => new
                {
                    b.Name,
                    TopBooks = b.CategoryBooks.OrderByDescending(bc => bc.Book.ReleaseDate).Select(a => new
                    {
                        a.Book.Title,
                        a.Book.ReleaseDate.Value.Year
                    }).Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            foreach (var category in categoriesGroup)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.TopBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }
            };

            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToList();
            foreach (var book in books)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Copies < 4200).ToList();

            int removedBooks = books.Count;

            foreach (var book in books)
            {
                context.Books.Remove(book);
            }

            context.SaveChanges();

            return removedBooks;
        }
    }
}
