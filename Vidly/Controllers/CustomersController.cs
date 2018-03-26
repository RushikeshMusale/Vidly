using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

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
            var membersipTypes = _context.MembershipTypes.ToList();
            NewCustomerViewModel ViewModel = new NewCustomerViewModel
            {
                MembershipTypes = membersipTypes
            };
            return View(ViewModel);
        }

        [HttpPost]
        // Here parameter customer will work because when Customer/New is submitted
        // it will send Customer object as we have bound NewCustomerViewModel.Customer 
        // (indirectly Customer)to the HTML controls
        // NOTE: Parameter name should be customer here
        public ActionResult Create(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        //[HttpPost] 
        // If we are using NewCustomerViewModel parameter, any name would work
        // for ex. here nc
        //public ActionResult Create(NewCustomerViewModel nc)
        //{
        //    _context.Customers.Add(nc.Customer);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index","Customer");
        //}
    }
}