using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.Models
{
    public class Job
    {
        public Job() { }
        [Key]
        public int ID { get; set; }
        public string Technician { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Finished { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        public virtual Customer Customer { get; set; }
    }
}