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
            Models.JobDTO dtoData = new Models.JobDTO();
            DataAccess dtoDataAccess = new DataAccess();
            dtoData = dtoDataAccess.GetJobDTO();
            return View(dtoData);
        }
        
        [HttpPost]
        public ActionResult CreateJob(int CustomerID, string JobTechnician, DateTime JobCreated, DateTime? JobFinished,List<int> ServiceList)
        {
            Models.JobDTO dtoData = new Models.JobDTO();
            DataAccess dtoDataAccess = new DataAccess();
            dtoData = dtoDataAccess.GetJobDTO();
            if (ServiceList != null && ServiceList.Count > 0)
            {
                foreach (var service in ServiceList) {
                    ViewBag.Message += " " + service;
                }
                //ViewBag.Message = ServiceList;
            }
            return View(dtoData);
        }
        [HttpGet]
        public ActionResult EditJob()
        {
            Models.JobDTO dtoData = new Models.JobDTO();
            DataAccess jobDTOData = new DataAccess();
            dtoData = jobDTOData.GetJobDTO();
            return View(dtoData);
        }
        [HttpPost]
        public ActionResult EditJob(int b)
        {
            Models.JobDTO dtoData = new Models.JobDTO();
            DataAccess jobDTOData = new DataAccess();
            dtoData = jobDTOData.GetJobDTO();
            return View(dtoData);
        }
        [HttpGet]
        public ActionResult DeleteJob()
        {
            List<Models.Job> jobList = new List<Models.Job>();
            JobDataAccess jobData = new JobDataAccess();
            jobList = jobData.GetJobList();
            return View(jobList);
        }
        public ActionResult DeleteJob(int JobID)
        {
            List<Models.Job> jobList = new List<Models.Job>();
            JobDataAccess jobData = new JobDataAccess();
            jobList = jobData.GetJobList();
            return View(jobList);
        }


    }
}