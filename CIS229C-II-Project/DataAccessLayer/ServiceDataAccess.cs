using CIS229C_II_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CIS229C_II_Project.DataAccessLayer
{
    public class ServiceDataAccess
    {
            public List<Service> GetService()
            {
                List<Service> services = new List<Service>();
                string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

                using (SqlConnection sqlConnection = new SqlConnection(connString))
                {
                    try
                    {
                        sqlConnection.Open();
                        using (SqlCommand cmd = new SqlCommand("GetServiceList", sqlConnection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandTimeout = 0;

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    Service serv = new Service
                                    {
                                        service_id = Convert.ToInt32(reader["service_id"]),
                                        service_name = reader["service_name"].ToString(),
                                        service_description = reader["service_description"].ToString(),
                                        service_price = Convert.ToInt32(reader["service_price"]),
                                    };

                                    services.Add(serv);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        sqlConnection.Close();
                    }
                }
                return services;
            }
            public bool CreateService(int customerID, string technician, DateTime created)
        {
            bool success = true;
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "CreateService";
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
        public bool EditService(int id, int customerID, string technician, DateTime created, DateTime? finished = null)
        {
            bool success = true;
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "EditService";
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
                            (reader.IsDBNull(reader.GetOrdinal("job_finished")) || Convert.ToDateTime(reader["job_finished"]).Equals(finished)))

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
        public bool DeleteService(int id)
        {
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "DeleteService";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@service_id", SqlDbType.Int).Value = id;
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