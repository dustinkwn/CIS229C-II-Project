using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CIS229C_II_Project.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CreateCustomer()
        {
            return View();
        }
        public ActionResult EditCustomer() // Needs a list of existing customers
        {
            List<Models.Customer> customerList = new List<Models.Customer>();
            return View(customerList);
        }
        public ActionResult DeleteCustomer() //  Needs a list of existing customers
        {
            List<Models.Customer> customerList = new List<Models.Customer>();
            return View(customerList);
        }

    }
}