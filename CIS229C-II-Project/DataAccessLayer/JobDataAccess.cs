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

            try
            {
                sqlConnection.Open();
                String query = "GetReceiptList";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Finds correct job
                        for (int i = 0; i < jobs.Count; i++)
                        {
                            if (Convert.ToInt32(reader["job_id"]) == jobs.ElementAt(i).JobID)
                            {
                                // Adds the service id to the object
                                jobs.ElementAt(i).Services.Add(Convert.ToInt32(reader["service_id"]));
                            }
                        }

                        
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
        public bool CreateJob(int customerID, string technician, DateTime created,DateTime? finished, List<int> serviceIDs)
        {
            if (serviceIDs == null) 
            {
                return false;
            }
            bool success = true;
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            int jobID = -1;
            try
            {
                sqlConnection.Open();
                String query = "CreateJob";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@JobTechnician", SqlDbType.VarChar).Value = technician;
                cmd.Parameters.AddWithValue("@JobCreated", SqlDbType.DateTime).Value = created;
                if (finished != null)
                {
                    cmd.Parameters.AddWithValue("@JobFinished", SqlDbType.DateTime).Value = finished;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@JobFinished", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.Int).Value = customerID;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Checks that the record is in the system 
                        if (Convert.ToInt32(reader["customer_id"]).Equals(customerID) && reader["job_technician"].ToString().Equals(technician)
                            && Convert.ToDateTime(reader["job_created"]).Equals(created))
                        {
                            success = true;
                            jobID = Convert.ToInt32(reader["job_id"]);
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
            if (jobID == -1 || success == false)
            {
                return false;
            }
            try
            {
                sqlConnection.Open();
                // Delete old receipt entries
                String query = "DeleteLinkJobService";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                // Creates receipt records to link one job with many services
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@JobID", SqlDbType.Int).Value = jobID;
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
                return false;
            }

            try
            {
                sqlConnection.Open();
                // Link new Entries
                String query = "LinkJobService";
                SqlCommand cmd;
                // Creates receipt records to link one job with many services
                if (serviceIDs != null)
                {
                    foreach (int serviceNum in serviceIDs)
                    {

                        cmd = new SqlCommand(query, sqlConnection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@JobID", SqlDbType.Int).Value = jobID;
                        cmd.Parameters.AddWithValue("@ServiceID", SqlDbType.Int).Value = serviceNum;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if (Convert.ToInt32(reader["job_id"]).Equals(jobID) && serviceIDs.Contains(Convert.ToInt32(reader["service_id"])))
                                {
                                    success = true;

                                }
                                else
                                {
                                    success = false;
                                    break;
                                }
                            }
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

        public bool EditJob(int jobID, int customerID, string technician, DateTime created, DateTime? finished, List<int> serviceIDs)
        {
            if (serviceIDs == null)
            {
                return false;
            }
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

                cmd.Parameters.AddWithValue("@JobID", SqlDbType.Int).Value = jobID;
                cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.Int).Value = customerID;
                cmd.Parameters.AddWithValue("@JobTechnician", SqlDbType.VarChar).Value = technician;
                cmd.Parameters.AddWithValue("@JobCreated", SqlDbType.DateTime).Value = created;
                if (finished != null)
                {
                    cmd.Parameters.AddWithValue("@JobFinished", SqlDbType.DateTime).Value = finished;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@JobFinished", DBNull.Value);
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["job_id"]).Equals(jobID) && reader["job_technician"].ToString().Equals(technician)
                            && Convert.ToDateTime(reader["job_created"]).Equals(created) && Convert.ToInt32(reader["customer_id"]).Equals(customerID) &&
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

            try
            {
                sqlConnection.Open();
                // Delete old receipt entries
                String query = "DeleteLinkJobService";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                // Creates receipt records to link one job with many services
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@JobID", SqlDbType.Int).Value = jobID;
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
                return false;
            }

            try
            {
                sqlConnection.Open();
                // Link new entries
                String query = "LinkJobService";
                SqlCommand cmd;
                // Creates receipt records to link one job with many services
                foreach (int serviceNum in serviceIDs)
                {

                    cmd = new SqlCommand(query, sqlConnection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@JobID", SqlDbType.Int).Value = jobID;
                    cmd.Parameters.AddWithValue("@ServiceID", SqlDbType.Int).Value = serviceNum;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToInt32(reader["job_id"]).Equals(jobID) && serviceIDs.Contains(Convert.ToInt32(reader["service_id"])))
                            {
                                success = true;

                            }
                            else
                            {
                                success = false;
                                break;
                            }
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