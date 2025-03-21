using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.Models
{
    public class Service
    {
        public Service() { }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
    }
}