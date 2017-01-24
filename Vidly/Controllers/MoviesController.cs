using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Sherk!" };

            // Pass Data into a view using the ViewData dictonary, which is a property avaliable to all Controller classes
            // Probledim with this approach, ViewData[Moview], stores an object, you have to cast, when you change the the key in the controller,
            // you have to change the key in the view, making it fragile. 
            ViewData["Movie"] = movie;

            // Viewbag is a dynamic type and another way of passing data to the view, it uses a magic property which is evaluated at runtime
            // Don't get compile time safety.
            // Basically has the same problems that ViewData has.
            ViewBag.Movie = movie;

            // Don't use ViewBag and ViewData. Bad Idea Mkaay


            var viewResult = new ViewResult();
            // This is how a viewResult Action is passed to a view.
            viewResult.ViewData.Model = movie;

            return View(movie);

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
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));

        }


        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


    }
}