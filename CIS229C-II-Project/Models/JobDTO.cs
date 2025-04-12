using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.Models
{
    public class JobDTO
    {
        // Basically our database
        // This Class is used to transfer data from a query to local objects Holds all the data.
        public JobDTO()
        {
            CustomerList = new List<Customer>(); 
            ServiceList = new List<Service>();
            JobList = new List<Job>();
        }

        public List<Customer> CustomerList { get; set; }
        public List<Service> ServiceList { get; set; }
        public List<Job> JobList { get; set; }

        public Customer GetCustomerByID (int id)
        {
            foreach (Customer customer in CustomerList)
            {
                if (customer.ID == id)
                {
                    return customer;
                }
            }
            return null;
        }
        public Service GetServiceByID(int serviceID)
        {
            foreach (Service service in ServiceList)
            {
                if (service.service_id == serviceID) //////////////////////////////
                {
                    return service;
                }
            }
            return null;
        }


    }
    
}