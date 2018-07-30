using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using BooklyReview.Models;
using BooklyReview.Dtos;

namespace BooklyReview.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            var customer = _context.Customers.SingleOrDefault(

                c => c.Id == newRental.CustomerId);

            if (newRental.BookIds.Count == 0)
                return BadRequest("No MovieIds have been given.");


            if (customer == null)
                return BadRequest("CustomerId is not valid.");


            var books = _context.Books.Where(
                m => newRental.BookIds.Contains(m.Id)).ToList();

            if (books.Count !=)
            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is not available.");
                book.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };
                _context.Rentals.Add(rental);           
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
