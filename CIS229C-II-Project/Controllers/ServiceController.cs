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
        public ActionResult CreateService(string ServiceName, string ServiceDescription, decimal ServicePrice) //Names have to match the form and be case sensitive
        {
            // No model is needed since there is no "custom" fields or drop down lists
            ServiceDataAccess serviceData = new ServiceDataAccess();
            bool success = serviceData.CreateService(ServiceName, ServiceDescription, ServicePrice);

            // Added success error output modified from your deletion
            if (success)
            {
                ViewBag.Message = "Service successfully created.";
            }
            else
            {
                ViewBag.Message = "There was an error creating the service.";
            }

            return View();
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditService(int ServiceID, string ServiceName, string ServiceDescription, decimal ServicePrice)
        {
            ServiceDataAccess serviceData = new ServiceDataAccess();
            bool success = serviceData.EditService(ServiceID, ServiceName, ServiceDescription, ServicePrice);
            List<Models.Service> servicesList = serviceData.GetServiceList();
            if (success)
            {
                ViewBag.Message = "Service successfully created.";
            }
            else
            {
                ViewBag.Message = "Error editing service";
            }
            return View(servicesList);
        }
        [HttpGet]
        public ActionResult EditService()
        {
            ServiceDataAccess serviceData = new ServiceDataAccess();
            List<Models.Service> servicesList = serviceData.GetServiceList();

            return View(servicesList);
        }
        [HttpGet]
        public ActionResult DeleteService()
        {
            List<Models.Service> serviceList = new List<Models.Service>();
            ServiceDataAccess servData = new ServiceDataAccess();
            serviceList = servData.GetServiceList();
            return View(serviceList);
        }
        [HttpPost]
        public ActionResult DeleteService(int ServiceID)
        {
            ServiceDataAccess dataAccess = new ServiceDataAccess();
            bool success = dataAccess.DeleteService(ServiceID);

            if (success)
            {
                ViewBag.Message = "Service successfully deleted.";
            }
            else
            {
                ViewBag.Message = "There was an error deleting the service.";
            }

            List<Models.Service> serviceList = dataAccess.GetServiceList();
            return View(serviceList);
        }
        [HttpGet]
        public ActionResult ViewServiceList ()
        {
            // List for populating service list model for output
            List<Models.Service> serviceList = new List<Models.Service>();
            ServiceDataAccess serviceData = new ServiceDataAccess();
            serviceList = serviceData.GetServiceList();
            return View(serviceList);
        }
    }
}