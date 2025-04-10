using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS229C_II_Project.DataAccessLayer;

namespace CIS229C_II_Project.Controllers
{
    public class ServiceController : Controller
    {
        [HttpPost]
        public ActionResult CreateService(string serviceName, string serviceDescription, decimal servicePrice)
        {
           
            return View();
        }
        // GET: Service
        [HttpGet]
        public ActionResult CreateService()
        {
            List<Models.Service> customerServices = new List<Models.Service> ();
            DataAccess customerServiceData = new DataAccess();
            return View(customerServices);
        }

        [HttpGet]
        public ActionResult EditService()
        {
            List<Models.Service> servicesList = new List<Models.Service>();
            DataAccess serviceData = new DataAccess();
            return View(servicesList);
        }

        [HttpGet]
        public ActionResult DeleteService()
        {
            List<Models.Service> servicesL = new List<Models.Service>();
            DataAccess serviceDataL = new DataAccess();
            return View(serviceDataL);
        }
    }
}