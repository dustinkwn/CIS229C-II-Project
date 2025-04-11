using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CIS229C_II_Project.DataAccessLayer;
using CIS229C_II_Project.Models;

namespace CIS229C_II_Project.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        [HttpGet]
        public ActionResult CreateJob()
        {
            // DTO data is needed so that the form can display the customers and services to pick from 
            Models.JobDTO dtoData = new Models.JobDTO();
            DataAccess dtoDataAccess = new DataAccess();
            dtoData = dtoDataAccess.GetJobDTO();
            return View(dtoData);
        }
        
        [HttpPost]
        public ActionResult CreateJob(int CustomerID, string JobTechnician, DateTime JobCreated, DateTime? JobFinished,List<int> ServiceList)
        {
            // DTO data for populating form options
            Models.JobDTO dtoData = new Models.JobDTO();
            DataAccess dtoDataAccess = new DataAccess();
            dtoData = dtoDataAccess.GetJobDTO();

            // Running Create operation
            JobDataAccess jobDataAccess = new JobDataAccess();
            bool success = jobDataAccess.CreateJob(CustomerID, JobTechnician, JobCreated, JobFinished, ServiceList);

            // *Testing the service list since it is a checkbox and haven't used this before
            /*if (ServiceList != null && ServiceList.Count > 0)
            {
                foreach (var service in ServiceList) {
                    ViewBag.Message += " " + service;
                }
            }
            */

            // Returns feedback to the user about if the job create worked
            if (success)
            {
                ViewBag.Message = "Job Successfully Created";
            }
            else
            {
                ViewBag.Message = "Job Creation Failed";
            }
            return View(dtoData);
        }

        [HttpGet]
        public ActionResult EditJob()
        {
            // This DTO's data of Customers, Services, and Jobs are needed to populate this form
            Models.JobDTO dtoData = new Models.JobDTO();
            DataAccess jobDTOData = new DataAccess();
            dtoData = jobDTOData.GetJobDTO();
            return View(dtoData);
        }

        [HttpPost]
        public ActionResult EditJob(int JobID, int CustomerID, string JobTechnician, DateTime JobCreated, DateTime? JobFinished, List<int> ServiceList)
        {
            // DTO populates the form with options
            Models.JobDTO dtoData = new Models.JobDTO();
            DataAccess jobDTOData = new DataAccess();
            dtoData = jobDTOData.GetJobDTO();

            // Running Edit operation
            JobDataAccess jobDataAccess = new JobDataAccess();
            bool success = jobDataAccess.EditJob(JobID, CustomerID, JobTechnician, JobCreated, JobFinished, ServiceList);

            // Returns feedback to the user about if the changes worked
            if (success)
            {
                ViewBag.Message = "Job Successfully Edited";
            }
            else
            {
                ViewBag.Message = "Job Edit Failed";
            }

            return View(dtoData);
        }

        [HttpGet]
        public ActionResult DeleteJob() 
        {
            // This form only needs the list of jobs to for the drop down list to delete
            List<Models.Job> jobList = new List<Models.Job>();
            JobDataAccess jobData = new JobDataAccess();
            jobList = jobData.GetJobList();
            return View(jobList);
        }
        public ActionResult DeleteJob(int JobID)
        {
            // Populates the ddl for jobs to delete
            List<Models.Job> jobList = new List<Models.Job>();
            JobDataAccess jobData = new JobDataAccess();
            jobList = jobData.GetJobList();

            // Running Delete operation
            JobDataAccess jobDataAccess = new JobDataAccess();
            bool success = jobDataAccess.DeleteJob(JobID);

            // Returns feedback to the user about if the deletion worked
            if (success)
            {
                ViewBag.Message = "Job Successfully Deleted";
            }
            else
            {
                ViewBag.Message = "Job Delete Failed";
            }

            return View(jobList);
        }

        [HttpGet]
        public ActionResult ViewJobList ()
        {
            // List for populating job list model for output
            List<Models.Job> jobList = new List<Models.Job>();
            JobDataAccess jobData = new JobDataAccess();
            jobList = jobData.GetJobList();
            return View(jobList);
        }


    }
}