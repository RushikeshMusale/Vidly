using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;
using System.Data.Entity.Infrastructure;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Movies
        public ActionResult Index()
        {
            var moviesList = _context.Movies.Include(m => m.Genre).ToList();
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
            var viewModel = new MovieFormViewModel()
            {
                
                GenreType = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var viewModel = new MovieFormViewModel(movie)
                    {                        
                        GenreType = _context.Genres.ToList()
                    };
                    return View("MovieForm", viewModel);
                }
                if (movie.Id == 0)
                {
                    movie.DateAdded = DateTime.Now;
                    _context.Movies.Add(movie);
                }
                else
                {
                    var movieInDB = _context.Movies.Single(m => m.Id == movie.Id);

                    movieInDB.Name = movie.Name;
                    movieInDB.NumberInStock = movie.NumberInStock;
                    movieInDB.GenreId = movie.GenreId;
                    movieInDB.ReleaseDate = movie.ReleaseDate;
                }
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                Console.WriteLine(e);
                throw;
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {                
                GenreType = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}