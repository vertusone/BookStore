using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        StoreContext db;

        public BookController(StoreContext context)
        {
            db = context;
            if (!db.Books.Any())
            {
                db.Books.AddRange(
                    new Book {Title = "Ulysses", Author = "James Joyce", Price = 32},
                    new Book {Title = "Don Quixote", Author = "Miguel de Cervantes", Price = 25},
                    new Book {Title = "Moby Dick", Author = "Herman Melville", Price = 41}
                );
                db.SaveChanges();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index(string title)
        {
            List<Book> books;
            
            if (!String.IsNullOrEmpty(title))
            {
                books = await db.Books.Where(x => x.Title.StartsWith(title)).ToListAsync();
            }
            else
            {
                books = await db.Books.ToListAsync();
            }

            return View(books);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            ViewBag.BookId = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Book");
            }

            return View(book);
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.DateTime = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return $"Dear {purchase.Person}, we will call you!";
        }
    }
}