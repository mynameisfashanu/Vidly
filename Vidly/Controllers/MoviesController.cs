using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;




namespace Vidly.Controllers
{


    public class MoviesController : Controller
    {


        private List<Movie> movies { get; set; }

        public MoviesController() : base()
        {
            movies = new List<Movie>
            {
                new Movie { Id = 1, Name = "The Matrix" },
                new Movie { Id = 2, Name = "Shingeki No Kyojin" },
                new Movie { Id = 3, Name = "Hello World" } 
            };

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

            // Pass Data into a view using the ViewData dictonary, which is a property avaliable to all Controller classes
            // Probledim with this approach, ViewData[Moview], stores an object, you have to cast, when you change the the key in the controller,
            // you have to change the key in the view, making it fragile. 
            //ViewData["Movie"] = movie;

            // Viewbag is a dynamic type and another way of passing data to the view, it uses a magic property which is evaluated at runtime
            // Don't get compile time safety.
            // Basically has the same problems that ViewData has.
            //ViewBag.Movie = movie;

            // Don't use ViewBag and ViewData. Bad Idea Mkaay


            //var viewResult = new ViewResult();
            // This is how a viewResult Action is passed to a view.
            //viewResult.ViewData.Model = movie;

            return View(viewModel);

            //return View(movie);
            // return new ViewResult();
            // return Content("Hello World");
            // return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new {page = 1, sortby = "name"});
        }


        public ActionResult Edit(int id)
        {
            return Content("ID = " + id);
        }

        
        
        // Returns a view with a list of movies in the database.
        // If you want to make a parameter in an action optional, you make it nullable(You can set the value to null),
        // You use a question mark, strings are a reference type and 
        //

        public ActionResult Index()
        {

            var moviesViewModel = new MovieViewModel
            {
                Movies = movies
            };

            return View(moviesViewModel);
        }

        public ActionResult Detail(int? id)
        {

            foreach(var movie in movies)
            {
                if (movie.Id == id)
                    return View(movie);
            }
            return HttpNotFound();

        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}