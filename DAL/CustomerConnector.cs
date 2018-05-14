using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CustomerConnector
    {

        public Customer GetOneCustomer(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                Customer customer = new Customer();
                con.ConnectionString = @"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;";

                SqlCommand command = new SqlCommand("GetOneCustomer", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    customer = new Customer();
                    customer.Id = int.Parse(reader["ID"].ToString());
                    customer.Username = reader["username"].ToString();
                    customer.Password = reader["password"].ToString();
                    customer.Email = reader["email"].ToString();
                    customer.Phonenumber = reader["phonenumber"].ToString();
                    customer.Streetname = reader["streetname"].ToString();
                    customer.Streetnumber = reader["streetnumber"].ToString();
                    customer.Zipcode = reader["zipcode"].ToString();
                    customer.City = reader["city"].ToString();


                }
                con.Close();
                con.Dispose();
                return customer;
            }
        }
        public List<Customer> GetCustomers()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;";
                con.Open();
                SqlCommand command = new SqlCommand("GetAllCustomer", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                List<Customer> CustomerList = new List<Customer>();
                Customer customer;

                while (reader.Read())
                {
                    customer = new Customer
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        Username = reader["username"].ToString(),
                        Password = reader["password"].ToString(),
                        Email = reader["email"].ToString(),
                        Phonenumber = reader["phonenumber"].ToString(),
                        Streetname = reader["streetname"].ToString(),
                        Streetnumber = reader["streetnumber"].ToString(),
                        Zipcode = reader["zipcode"].ToString(),
                        City = reader["city"].ToString(),

                    };
                    CustomerList.Add(customer);

                }
                return CustomerList;
            }
        }
        public void CreateOneCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection())
            {
                SqlConnection sqlConnection1 =
               new SqlConnection(@"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;");
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "CreateCustomer";
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = customer.Username;
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = customer.Password;
                    command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = customer.Email;
                    command.Parameters.Add("@phonenumber", SqlDbType.NVarChar, 50).Value = customer.Phonenumber;
                    command.Parameters.Add("@streetname", SqlDbType.NVarChar, 50).Value = customer.Streetname;
                    command.Parameters.Add("@streetnumber", SqlDbType.NVarChar, 50).Value = customer.Streetnumber;
                    command.Parameters.Add("@zipcode", SqlDbType.NVarChar, 50).Value = customer.Zipcode;
                    command.Parameters.Add("@city", SqlDbType.NVarChar, 50).Value = customer.City;



                    command.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
                catch (SqlException e)
                {

                }

            }
        }
        public void UpdateOneCustomer(Customer customer)
        {
            using (SqlConnection con = new SqlConnection())
            {
                SqlConnection sqlConnection1 =
               new SqlConnection(@"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;");
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UpdateOneCustomer";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = customer.Id;
                    command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = customer.Username;
                    command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = customer.Password;
                    command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = customer.Email;
                    command.Parameters.Add("@phonenumber", SqlDbType.NVarChar, 50).Value = customer.Phonenumber;
                    command.Parameters.Add("@streetname", SqlDbType.NVarChar, 50).Value = customer.Streetname;
                    command.Parameters.Add("@streetnumber", SqlDbType.NVarChar, 50).Value = customer.Streetnumber;
                    command.Parameters.Add("@zipcode", SqlDbType.NVarChar, 50).Value = customer.Zipcode;
                    command.Parameters.Add("@city", SqlDbType.NVarChar, 50).Value = customer.City;
                    command.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
                catch (SqlException e)
                {

                }
            }
        }
        public void DeleteOneCustomer(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                SqlConnection sqlConnection1 =
               new SqlConnection(@"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;");
                try
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlConnection1;
                    sqlConnection1.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "DeleteOneCustomer";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
                catch (SqlException e)
                {

                }

            }
        }
    }
}
