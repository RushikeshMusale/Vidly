using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context = new ApplicationDbContext();
        // GET: Customers
        public ActionResult Index()
        {
            //here Include is used to eager load MembershipType object
            //if Include is not used MembershipType will be null
            //**Include is an extension method & defined in System.Data.Entity
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
           
            return View(customers);
        }

        //Important method when using db context.
        //Do not forgot to add
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if(customer==null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult New()
        {
           
            return View();
        }
    }
}