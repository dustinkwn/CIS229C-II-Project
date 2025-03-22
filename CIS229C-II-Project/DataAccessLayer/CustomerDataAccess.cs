using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using CIS229C_II_Project.Models;

namespace CIS229C_II_Project.DataAccessLayer
{
    public class CustomerDataAccess
    {
        public List<Models.Customer> GetCustomerList() 
        { 
            List<Models.Customer> customers = new List<Models.Customer>();

            // database object access
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "GetCustomerList";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Customer tempCustomer = new Customer();

                        tempCustomer.ID = Convert.ToInt32(reader["customer_id"]);
                        tempCustomer.FirstName = reader["customer_fname"].ToString(); 
                        tempCustomer.LastName = reader["customer_lname"].ToString();
                        tempCustomer.Email = reader["customer_email"].ToString();
                        tempCustomer.Phone = reader["customer_phone"].ToString();

                        customers.Add(tempCustomer);
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception e)
            {
                sqlConnection.Close();
            }

            return customers;
        }
        public bool CreateCustomer(string firstName, string lastName, string email, string phoneNumber)
        {
            // database record creation
            bool success = true;
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "CreateCustomer";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@CustomerFirstName", SqlDbType.VarChar).Value = firstName;
                cmd.Parameters.AddWithValue("@CustomerLastName", SqlDbType.VarChar).Value = lastName;
                cmd.Parameters.AddWithValue("@CustomerEmail", SqlDbType.VarChar).Value = email;
                cmd.Parameters.AddWithValue("@CustomerPhone", SqlDbType.VarChar).Value = phoneNumber;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        if (reader["customer_fname"].ToString().Equals(firstName) && reader["customer_lname"].ToString().Equals(lastName) 
                            && reader["customer_email"].ToString().Equals(email) && reader["customer_phone"].ToString().Equals(phoneNumber))
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
        public bool EditCustomer(int customerID, string firstName, string lastName, string email, string phoneNumber)
        {
            // database update code
            bool success = true;
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "EditCustomer";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;

                cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.Int).Value = customerID;
                cmd.Parameters.AddWithValue("@CustomerFirstName", SqlDbType.VarChar).Value = firstName;
                cmd.Parameters.AddWithValue("@CustomerLastName", SqlDbType.VarChar).Value = lastName;
                cmd.Parameters.AddWithValue("@CustomerEmail", SqlDbType.VarChar).Value = email;
                cmd.Parameters.AddWithValue("@CustomerPhone", SqlDbType.VarChar).Value = phoneNumber;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["customer_fname"].ToString().Equals(firstName) && reader["customer_lname"].ToString().Equals(lastName)
                            && reader["customer_email"].ToString().Equals(email) && reader["customer_phone"].ToString().Equals(phoneNumber)
                            && Convert.ToInt32(reader["customer_id"]).Equals(customerID))
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
        public bool DeleteCustomer(int customerID)
        {
            // add database deletion
            String connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
            SqlConnection sqlConnection = new SqlConnection(connString);
            try
            {
                sqlConnection.Open();
                String query = "DeleteCustomer";
                SqlCommand cmd = new SqlCommand(query, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@CustomerID", SqlDbType.VarChar).Value = customerID;
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