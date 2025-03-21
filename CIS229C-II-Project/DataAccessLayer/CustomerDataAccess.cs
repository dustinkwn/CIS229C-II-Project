using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.DataAccessLayer
{
    public class CustomerDataAccess
    {
        public List<Models.Customer> GetCustomerList() 
        { 
            List<Models.Customer> customers = new List<Models.Customer>();

            // add database access

            return customers;
        }
        public bool CreateCustomer(string firstName, string lastName, string email, string phoneNumber)
        {
            // add database record creation
            return true;
        }
        public bool EditCustomer(int customerID, string firstName, string lastName, string email, string phoneNumber)
        {
            // add database update code
            return true;
        }
        public bool DeleteCustomer(int customerID)
        {
            // add database deletion
            return true;
        }
    }
}