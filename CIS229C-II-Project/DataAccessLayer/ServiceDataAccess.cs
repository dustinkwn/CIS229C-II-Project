using CIS229C_II_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CIS229C_II_Project.DataAccessLayer
{
    public class ServiceDataAccess
    {
            public List<Service> GetServiceList()
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
                                        service_price = Convert.ToDecimal(reader["service_cost"]),
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

            public bool CreateService(string serviceName, string serviceDescription, decimal servicePrice)
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
                    //cmd.Parameters.AddWithValue("@service_id", serviceId);
                    cmd.Parameters.AddWithValue("@service_name", serviceName);
                    cmd.Parameters.AddWithValue("@service_description", serviceDescription);
                    cmd.Parameters.AddWithValue("@service_price", servicePrice);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (Convert.ToDecimal(reader["service_cost"]).Equals(servicePrice) && reader["service_name"].ToString().Equals(serviceName)
                            && reader["service_description"].ToString().Equals(serviceDescription))
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
        public bool EditService(int serviceId, string serviceName, string serviceDescription, decimal servicePrice)
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

                cmd.Parameters.AddWithValue("@service_id", SqlDbType.Int).Value = serviceId;
                cmd.Parameters.AddWithValue("@service_name", SqlDbType.VarChar).Value = serviceName;
                cmd.Parameters.AddWithValue("@service_description", SqlDbType.VarChar).Value = serviceDescription;
                cmd.Parameters.AddWithValue("@service_price", SqlDbType.Decimal).Value = servicePrice;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (Convert.ToInt32(reader["service_id"]).Equals(serviceId) && reader["service_name"].ToString().Equals(serviceName)
                            && reader["service_description"].ToString().Equals(serviceDescription) && Convert.ToDecimal(reader["service_cost"]).Equals(servicePrice))

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