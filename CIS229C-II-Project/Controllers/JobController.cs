using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS229C_II_Project.DataAccessLayer;

namespace CIS229C_II_Project.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        [HttpGet]
        public ActionResult CreateJob()
        {
            List<Models.Customer> customerList = new List<Models.Customer>();
            CustomerDataAccess customerData = new CustomerDataAccess();
            customerList = customerData.GetCustomerList();
            return View(customerList);
        }
        [HttpGet]
        public ActionResult EditJob()
        {
            List<Models.JobDTO> jobDTOList = new List<Models.JobDTO>();
            DataAccess jobDTOData = new DataAccess();
            jobDTOList = jobDTOData.GetJobDTOList();
            return View(jobDTOList);
        }
        [HttpGet]
        public ActionResult DeleteJob()
        {
            List<Models.Job> jobList = new List<Models.Job>();
            JobDataAccess jobData = new JobDataAccess();
            jobList = jobData.GetJobList();
            return View(jobList);
        }

    }
}