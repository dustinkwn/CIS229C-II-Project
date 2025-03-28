using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.Models
{
    public class Service
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int service_id { get; set; }

        [Required]
        public string service_name { get; set; }

        public string service_description { get; set; }

        [Required]
        public int service_price { get; set; }

        public int CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}