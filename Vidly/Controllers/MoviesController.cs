using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

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

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel
            {
                GenreType = _context.Genres.ToList()
            };
            return View("MovieForm",viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}