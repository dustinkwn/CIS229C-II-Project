using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.Models
{
    public class JobDTO
    {
        // This Class is used to transfer data from a query to local objects
        public JobDTO() { }
        
        public int JobID { get; set; }
        public int CustomerID {  get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string TechnicianName { get; set; }
        public DateTime JobCreated { get; set; }
        public DateTime? JobFinished { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double ServiceCost { get; set; }
    }
    
}