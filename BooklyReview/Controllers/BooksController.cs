using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BooklyReview.Models;
using BooklyReview.ViewModels;

namespace BooklyReview.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;
        public BooksController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
            var books = _context.Books.ToList();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book = _context.Books.SingleOrDefault(m => m.Id == id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        // GET: Books/Random
        public ActionResult Random()
        {
            var book = new Book() { Name = "Life According To Garp" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomBookViewModel
            {
                Book = book,
                Customers = customers
            };

            return View(viewModel);
        }
    }

}
