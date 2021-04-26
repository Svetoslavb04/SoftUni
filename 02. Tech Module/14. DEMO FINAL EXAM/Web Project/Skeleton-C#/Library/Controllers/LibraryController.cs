using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class LibraryController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new BookDbContext())
            {
                var allbooks = db.Books.ToList();
                return View(allbooks);
            }            
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string title, string author, double price)
        {
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(author) || price < 1)
            {
                return RedirectToAction("Index");
            }
            Book book = new Book
            {
                title = title,
                author = author,
                price = price
            };
            using (var db = new BookDbContext())
            {
                db.Add(book);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            using(var db = new BookDbContext())
            {
                var bookToEdit = db.Books.FirstOrDefault(t => t.id == id);
                if (bookToEdit == null)
                {
                    return RedirectToAction("Index");
                }
                return this.View(bookToEdit);
            }
        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (book.price < 1)
            {
                return RedirectToAction("Index");
            }
            using (var db = new BookDbContext())
            {
                var bookToEdit = db.Books.FirstOrDefault(t => t.id == book.id);
                bookToEdit.title = book.title;
                bookToEdit.author = book.author;
                bookToEdit.price = book.price;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            using (var db = new BookDbContext())
            {
                Book bookToDelete = db.Books.FirstOrDefault(b => b.id == id);
                if (bookToDelete == null)
                {
                    RedirectToAction("Index");
                }
                return View(bookToDelete);
            }
        }

        [HttpPost]
        public IActionResult Delete(Book book)
        {
            using (var db = new BookDbContext())
            {
                Book bookToDelete = db.Books.FirstOrDefault(b => b.id == b.id);
                if (bookToDelete == null)
                {
                    RedirectToAction("Index");
                }
                db.Books.Remove(bookToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}