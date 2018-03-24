using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Movies
        public ActionResult Index()
        {
            var moviesList = _context.Movies.Include(m=>m.Genre).ToList();
            return View(moviesList);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Id=1,Name="Shrek" },
                new Movie {Id=2,Name="Wall-e" }
            };
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}