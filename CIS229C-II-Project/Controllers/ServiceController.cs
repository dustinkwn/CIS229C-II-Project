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
            Models.JobDTO DTOdata = new Models.JobDTO();
            DataAccess ServiceData = new DataAccess();
            DTOdata = ServiceData.GetJobDTO();
            return View(DTOdata);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            List<Models.Service> customerServices = new List<Models.Service> ();
            DataAccess customerServiceData = new DataAccess();
            return View(customerServices);
        }
        [HttpPost]
        public ActionResult EditService(int id)
        {
            Models.JobDTO DTOdata = new Models.JobDTO();
            DataAccess ServiceDTOData = new DataAccess();
            DTOdata = ServiceDTOData.GetJobDTO();
            return View(DTOdata);
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
    }
}