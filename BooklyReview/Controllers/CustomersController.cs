using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using BooklyReview.Models;
using BooklyReview.ViewModels;

namespace BooklyReview.Controllers
{
    public class CustomersController : Controller

    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose(); 
        }

        public ViewResult Index()
        {
            // Deferred execution until customers object is itterated over if no helper function is called (e.g. _context.Customers) 
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Details(int id)
        {   // Query   is immediately executed because using SingleOrDefault function.
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {

                // AutoMapper could use Mapped.Map(customer, customerInDb)
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;


            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel

            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
        
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

    }
}