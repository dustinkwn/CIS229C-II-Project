using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.Models
{
    public class Job : Outputable
    {
        public string GetString()
        {
            string finished = "";
            if (JobFinished == null)
            {
                finished = "Incomplete";
            }
            else
            {
                finished = "Done";
            }
            return finished + " Cust: " + CustomerID + " Tech: " + JobTechnician + " Start: " + JobCreated + " Finish: " + JobFinished;
        }
        public Job()
        {
            JobID = -1;
            CustomerID = -1;
            JobTechnician = "";
            JobCreated = DateTime.Now;
            JobFinished = null;
            Services = new List<int>();
        }
        public int JobID { get; set; }
        public int CustomerID { get; set; }
        public string JobTechnician { get; set; }
        public DateTime JobCreated { get; set; }
        public DateTime? JobFinished { get; set; }
        public List<int> Services { get; set; }
    }
}