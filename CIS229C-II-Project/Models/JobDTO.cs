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
        public JobDTO(int jobID,int customerID, string customerFirstName, string customerLastName, string customerPhone, string customerEmail, 
            string technicianName, DateTime jobCreated, DateTime jobCompleted,int serviceID, string serviceName, string serviceDescription,
            double serviceCost) 
        {
            JobID = jobID;
            CustomerID = customerID;
            CustomerFirstName = customerFirstName;
            CustomerLastName = customerLastName;
            CustomerPhone = customerPhone;
            CustomerEmail = customerEmail;
            TechnicianName = technicianName;
            JobCreated = jobCreated;
            JobCompleted = jobCompleted;
            ServiceID = serviceID;
            ServiceName = serviceName;
            ServiceDescription = serviceDescription;
            ServiceCost = serviceCost;
        }
        public int JobID { get; set; }
        public int CustomerID {  get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string TechnicianName { get; set; }
        public DateTime JobCreated { get; set; }
        public DateTime? JobCompleted { get; set; }
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public double ServiceCost { get; set; }
    }
    
}