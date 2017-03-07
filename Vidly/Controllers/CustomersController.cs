using System;
using System.Collections.Generic;
using System.Data.Entity; // Error because Include extension method is defined in different name space
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
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

        public ActionResult CustomerForm()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                Membershiptypes = membershipTypes
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer) // model binding - mvc binds model to request data.
        {

            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    Membershiptypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            } 

            if(customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //TryUpdateModel(customerInDb); // Introduces security vulnerabilites, update all request data.

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Detail(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer != null)
                return View(customer);

            return HttpNotFound();
        }


        public ActionResult Edit(int ? id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                var viewModel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    Membershiptypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel); // Return CustomerForm View, instead of a View Called Edit
            }
            return HttpNotFound();
        }
    }
}