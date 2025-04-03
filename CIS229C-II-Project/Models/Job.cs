using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.Models
{
    public class Job
    {
        public Job() { }
        public int ID { get; set; }
        public string Technician { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Finished { get; set; }
        public int CustomerID { get; set; }
        public List<Service> ServiceList { get; set; }
    }
}