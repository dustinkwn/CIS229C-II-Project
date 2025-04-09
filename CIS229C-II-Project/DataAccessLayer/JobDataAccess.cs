using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using CIS229C_II_Project.Models;
using System.Web.Helpers;

namespace CIS229C_II_Project.DataAccessLayer
{
    public class JobDataAccess
    {
        public List<Models.Job> GetJobList ()
        {
            List<Models.Job> jobs = new List<Models.Job>();
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "GetJobList";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Job tempJob = new Job();

                        tempJob.JobID = Convert.ToInt32(reader["job_id"]);
                        tempJob.CustomerID = Convert.ToInt32(reader["customer_id"]);
                        tempJob.JobTechnician = reader["job_technician"].ToString();
                        tempJob.JobCreated = Convert.ToDateTime(reader["job_created"]);
                        
                        if (reader.IsDBNull(reader.GetOrdinal("job_finished")))
                        {
                            tempJob.JobFinished = null;
                        }
                        else
                        {
                            tempJob.JobFinished = Convert.ToDateTime(reader["job_finished"]);
                        }

                        jobs.Add(tempJob);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
            }
            return jobs;
        }
        public bool CreateJob(int customerID, string technician, DateTime created)
        {
            bool success = true;
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "CreateJob";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@JobTechnician", SqlDbType.VarChar).Value = technician;
                cmd.Parameters.AddWithValue("@JobCreated", SqlDbType.DateTime).Value = created;
                cmd.Parameters.AddWithValue("@JobFinished", SqlDbType.DateTime).Value = null;
                cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.Int).Value = customerID;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["customer_id"]).Equals(customerID) && reader["job_technician"].ToString().Equals(technician))
                        {
                            success = true;
                            break;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
                return false;
            }
            return success;
        }
        public bool EditJob(int id, int customerID, string technician, DateTime created, DateTime? finished = null)
        {
            bool success = true;
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "EditJob";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@JobID", SqlDbType.Int).Value = id;
                cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.Int).Value = customerID;
                cmd.Parameters.AddWithValue("@JobTechnician", SqlDbType.VarChar).Value = technician;
                cmd.Parameters.AddWithValue("@JobCreated", SqlDbType.DateTime).Value = created;
                cmd.Parameters.AddWithValue("@JobFinished", SqlDbType.DateTime).Value = finished;
                
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["job_id"]).Equals(id) && reader["job_technician"].ToString().Equals(technician)
                            && Convert.ToDateTime(reader["job_created"]).Equals(created) && 
                            (reader.IsDBNull(reader.GetOrdinal("job_finished")) || Convert.ToDateTime(reader["job_finished"]).Equals(finished)) )
                            
                        {
                            success = true;
                            break;
                        }
                        else
                        {
                            success = false;
                        }
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
                return false;
            }
            return success;
        }
        public bool DeleteJob(int jobId)
        {
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "DeleteJob";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@JobID", SqlDbType.Int).Value = jobId;
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
                return false;
            }
            return true;
          
        }
    }
}