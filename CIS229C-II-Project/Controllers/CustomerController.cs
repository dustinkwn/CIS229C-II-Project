using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS229C_II_Project.DataAccessLayer;

namespace CIS229C_II_Project.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(string CustomerFirstName, string CustomerLastName, string CustomerEmail, string CustomerPhone)
        {
            // 
            CustomerDataAccess data = new CustomerDataAccess();
            bool success = data.CreateCustomer(CustomerFirstName, CustomerLastName, CustomerEmail, CustomerPhone);
            // Sets Viewbag Message based upon data creation success / fail
            if (success)
            {
                ViewBag.Message = "Customer Successfully Created";
            }
            else
            {
                ViewBag.Message = "Customer Creation Failed";
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditCustomer() // Needs a list of existing customers
        {
            // List for populating old customer drop down list
            List<Models.Customer> customerList = new List<Models.Customer>();
            CustomerDataAccess customerData = new CustomerDataAccess();
            customerList = customerData.GetCustomerList();
            return View(customerList);
        }

        [HttpPost]
        public ActionResult EditCustomer(int CustomerID, string CustomerFirstName, string CustomerLastName, string CustomerEmail, string CustomerPhone)
        {
            // List for populating old customer drop down list
            List<Models.Customer> customerList = new List<Models.Customer>();
            CustomerDataAccess customerData = new CustomerDataAccess();
            bool success = customerData.EditCustomer(CustomerID, CustomerFirstName, CustomerLastName, CustomerEmail, CustomerPhone);
            customerList = customerData.GetCustomerList();

            // Sets Viewbag Message based upon data edit success / fail
            if (success)
            {
                ViewBag.Message = "Customer Successfully Edited";
            }
            else
            {
                ViewBag.Message = "Customer Edit Failed";
            }
            return View(customerList);
        }

        [HttpGet]
        public ActionResult DeleteCustomer() //  Needs a list of existing customers
        {
            // List for populating customer to delete drop down list
            List<Models.Customer> customerList = new List<Models.Customer>();
            CustomerDataAccess customerData = new CustomerDataAccess();
            customerList = customerData.GetCustomerList();
            return View(customerList);
        }

        [HttpPost]
        public ActionResult DeleteCustomer(int CustomerID)
        {
            // List for populating customer to delete drop down list
            List<Models.Customer> customerList = new List<Models.Customer>();
            CustomerDataAccess customerData = new CustomerDataAccess();
            bool success = customerData.DeleteCustomer(CustomerID);
            customerList = customerData.GetCustomerList();

            // Sets Viewbag Message based upon data deletion success / fail
            if (success)
            {
                ViewBag.Message = "Customer Successfully Deleted";
            }
            else
            {
                ViewBag.Message = "Customer Delete Failed";
            }
            return View(customerList);
        }

        [HttpGet]
        public ActionResult ViewCustomerList()
        {
            // List for populating customer list model for output
            List<Models.Customer> customerList = new List<Models.Customer>();
            CustomerDataAccess customerData = new CustomerDataAccess(); 
            customerList = customerData.GetCustomerList();
            return View(customerList);
        }

    }
}