using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using CIS229C_II_Project.Models;

namespace CIS229C_II_Project.DataAccessLayer
{
    public class DataAccess
    {
        public JobDTO GetJobDTO ()
        {
            CustomerDataAccess customerData = new CustomerDataAccess ();
            ServiceDataAccess serviceData = new ServiceDataAccess ();
            JobDataAccess jobDataAccess = new JobDataAccess ();

            JobDTO dtoData = new JobDTO ();
            dtoData.CustomerList = customerData.GetCustomerList ();
            dtoData.ServiceList = serviceData.GetService();
            dtoData.JobList = jobDataAccess.GetJobList ();
            return dtoData;

        }
       
    }
}