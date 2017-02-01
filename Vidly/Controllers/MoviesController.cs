using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity; // error because Include extension method is defined in different name space




namespace Vidly.Controllers
{


    public class MoviesController : Controller
    {

        private ApplicationDbContext _context; 

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk!" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Customer 1" },
                new Customer { Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };


            return View(viewModel);

        }


        public ActionResult Edit(int id)
        {
            return Content("ID = " + id);
        }

        
       
        public ActionResult Index()
        {

            var moviesViewModel = new MovieViewModel
            {
                Movies = _context.Movies.Include(m => m.Genre).ToList()
            };

            return View(moviesViewModel);
        }

        public ActionResult Detail(int? id)
        {

            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie != null)
                    return View(movie);
            return HttpNotFound();

        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]

        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}