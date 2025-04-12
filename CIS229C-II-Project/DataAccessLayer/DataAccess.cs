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
        public JobDTO GetJobDTO()
        {
            CustomerDataAccess customerData = new CustomerDataAccess();
            ServiceDataAccess serviceData = new ServiceDataAccess();
            JobDataAccess jobDataAccess = new JobDataAccess();

            JobDTO dtoData = new JobDTO();
            dtoData.CustomerList = customerData.GetCustomerList();
            dtoData.ServiceList = serviceData.GetServiceList();
            dtoData.JobList = jobDataAccess.GetJobList();
            return dtoData;

        }
        public List<Models.DashboardModel> GetDashboardModels()
        {
            
            List<Models.DashboardModel> dashboardRecords = new List<Models.DashboardModel>();

            // database object access
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "GetDashboardModel";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DashboardModel tempModel = new DashboardModel();

                        tempModel.JobID = Convert.ToInt32(reader["job_id"]);
                        tempModel.JobTechnician = reader["job_technician"].ToString();
                        tempModel.JobCreated = Convert.ToDateTime(reader["job_created"]);
                        if (reader.IsDBNull(reader.GetOrdinal("job_finished")))
                        {
                            tempModel.JobFinished = null;
                        }
                        else
                        {
                            tempModel.JobFinished = Convert.ToDateTime(reader["job_finished"]);
                        }

                        tempModel.CustomerID = Convert.ToInt32(reader["customer_id"]);
                        tempModel.CustomerFirstName = reader["customer_fname"].ToString();
                        tempModel.CustomerLastName = reader["customer_lname"].ToString();
                        tempModel.CustomerEmail = reader["customer_email"].ToString();
                        tempModel.CustomerPhone = reader["customer_phone"].ToString();

                        tempModel.ServiceID = Convert.ToInt32(reader["service_id"]);
                        tempModel.ServiceName = reader["service_name"].ToString();
                        tempModel.ServiceDescription = reader["service_description"].ToString();
                        tempModel.ServiceCost = Convert.ToDecimal(reader["service_cost"]);

                        dashboardRecords.Add(tempModel);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
            }

            return dashboardRecords;
        }
    }
}