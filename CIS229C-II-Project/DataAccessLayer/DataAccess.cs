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
        public List<JobDTO> GetJobDTOList ()
        {
            List<JobDTO> jobDTOList = new List<JobDTO>();
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                string query = "GetJobDTOList";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JobDTO job = new JobDTO();
                        job.JobID = Convert.ToInt32(reader["job_id"]);
                        job.CustomerID = Convert.ToInt32(reader["customer_id"]);
                        job.CustomerFirstName = reader["customer_fname"].ToString();
                        job.CustomerLastName = reader["customer_lname"].ToString();
                        job.CustomerPhone = reader["customer_phone"].ToString();
                        job.CustomerEmail = reader["customer_email"].ToString();                        
                        job.TechnicianName = reader["customer_technician"].ToString();
                        job.JobCreated = Convert.ToDateTime(reader["job_created"]);

                        if (reader.IsDBNull(reader.GetOrdinal("job_finished")))
                        {
                            job.JobFinished= null;
                        }
                        else
                        {
                            job.JobFinished = Convert.ToDateTime(reader["job_finished"]);
                        }

                        job.ServiceID = Convert.ToInt32(reader["service_id"]);
                        job.ServiceName = reader["service_name"].ToString();
                        job.ServiceDescription = reader["service_description"].ToString();
                        job.ServiceCost = Convert.ToDouble(reader["service_cost"]);

                        jobDTOList.Add(job);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
            }
            
            return jobDTOList;
                
        }
    }
}