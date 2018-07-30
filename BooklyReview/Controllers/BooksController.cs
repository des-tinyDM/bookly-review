using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BooklyReview.Models;
using BooklyReview.ViewModels;
using System.Data.Entity.Validation;

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
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            else
                return View("ReadOnlyList");
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

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult New()
        {
            var genres = _context.Genres.ToList();

            var viewModel = new BookFormViewModel
            {
                Genres = genres
            };

            return View("BookForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return HttpNotFound();

            var viewModel = new BookFormViewModel(book)
            {
                Genres = _context.Genres.ToList()
            };

            return View("BookForm", viewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book)
        {

            if (book.Id == 0)
            {
                _context.Books.Add(book);
            }

            else
            {
                var movieInDb = _context.Books.Single(m => m.Id == book.Id);

                movieInDb.Name = book.Name;
                movieInDb.Author = book.Author;
                movieInDb.GenreId = book.GenreId;
                movieInDb.NumberInStock = book.NumberInStock;
                movieInDb.ReleaseDate = book.ReleaseDate;

            }

            _context.SaveChanges();
          return RedirectToAction("Index", "Books");
        }
    }
}
