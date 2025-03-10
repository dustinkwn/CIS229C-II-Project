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
            String connString = ConfigurationManager.ConnectionStrings["benConnString"].ToString();
            //String connString = ConfigurationManager.ConnectionStrings["dustinConnString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                string query = "";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        JobDTO job = new JobDTO();
                        job.JobID = Convert.ToInt32(reader["JobID"].ToString());
                        job.CustomerID = Convert.ToInt32(reader["CustomerID"].ToString());
                        job.CustomerFirstName = reader["CustomerFirstName"].ToString();
                        job.CustomerLastName = reader["CustomerLastName"].ToString();

                        if (reader["CustomerPhone"] == null)
                        {
                            job.CustomerPhone = "";
                        }
                        else
                        {
                            job.CustomerPhone = reader["CustomerPhone"].ToString();
                        }

                        if (reader["CustomerEmail"] == null)
                        {
                            job.CustomerEmail = "";
                        }
                        else
                        {
                            job.CustomerEmail = reader["CustomerEmail"].ToString();
                        }

                        
                        job.TechnicianName = reader["TechnicianName"].ToString();
                        job.JobCreated = Convert.ToDateTime(reader["JobCreated"].ToString());

                        if (reader["JobCompleted"] == null)
                        {
                            job.JobCompleted= null;
                        }
                        else
                        {
                            job.JobCompleted = Convert.ToDateTime(reader["JobCreated"].ToString());
                        }

                        job.ServiceID = Convert.ToInt32(reader["ServiceID"].ToString());
                        job.ServiceName = reader["ServiceName"].ToString();
                        job.ServiceDescription = reader["ServiceDescription"].ToString();
                        job.ServiceCost = Convert.ToDouble(reader["Cost"].ToString());

                        jobDTOList.Add(job);

                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                sqlConnection.Close();
                return null;
            }
            
            return jobDTOList;
                
        }
    }
}