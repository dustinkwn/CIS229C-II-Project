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
            if (Finished == null)
            {
                finished = "Incomplete";
            }
            else
            {
                finished = "Done";
            }
            return "Status: " + finished + " Customer: " + CustomerID + " Tech:" + Technician + " Start: " + Created;
        }
        public Job()
        {
            ID = -1;
            Technician = "";
            Created = new DateTime();
            Finished = null;
            CustomerID = -1;
            ServiceList = new List<Service>();
        }
        public int ID { get; set; }
        public string Technician { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Finished { get; set; }
        public int CustomerID { get; set; }
        public List<Service> ServiceList { get; set; }
    }
}