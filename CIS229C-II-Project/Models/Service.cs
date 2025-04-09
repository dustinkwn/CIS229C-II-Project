using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.Models
{
    public class Service
    {
        public int service_id { get; set; }
        public string service_name { get; set; }

        public string service_description { get; set; }

        public decimal service_price { get; set; }
    }
}