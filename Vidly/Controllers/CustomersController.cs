using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private List<Customer> customers { get; set; }

        public CustomersController() : base()
        {
            customers = new List<Customer>
            {
                new Customer {Id = 1, Name = "Fashanu Willies" },
                new Customer {Id = 2, Name = "Irene Willies" },
                new Customer {Id = 3, Name = "Guilot Willies" },
            };

        }

        // GET: Customers
        public ActionResult Index()
        {

            var viewModel = new CustomerViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }


        public ActionResult Detail(int? id)
        {
            foreach (var customer in customers)
            {
                if (customer.Id == id)
                    return View(customer);
            }
            return HttpNotFound();
        }
    }
}