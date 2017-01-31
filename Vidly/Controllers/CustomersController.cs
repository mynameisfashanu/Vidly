using System;
using System.Collections.Generic;
using System.Data.Entity; // error because Include extension method is defined in different name space
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

        // GET: Customers
        public ActionResult Index()
        {

            // views don't display model relationships by default.
            // we have to explicting tell the view to load model with associated models. 
            // we use th include extension method in linq to do this - this is known as eager loading.
            var viewModel = new CustomerViewModel
            {
                Customers = _context.Customers.Include(c => c.MembershipType).ToList() 
            };

            return View(viewModel);
        }


        public ActionResult Detail(int? id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer != null)
                return View(customer);

            return HttpNotFound();
        }

    }
}