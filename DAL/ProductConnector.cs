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
    public class ProductConnector 
    {
        private TableJoinner tj = new TableJoinner();
        public void Create(Product t)
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
                    command.CommandText = "CreateOneProduct";
                    command.Parameters.Add("@productName", SqlDbType.NVarChar, 50).Value = t.ProductName;
                    command.Parameters.Add("@price", SqlDbType.NVarChar, 50).Value = t.Price;
                    command.Parameters.Add("@information", SqlDbType.NVarChar).Value = t.Information;
                    command.Parameters.Add("@manufacture", SqlDbType.NVarChar, 50).Value = t.Manufacture;
                    command.Parameters.Add("@categoryId", SqlDbType.NVarChar, 50).Value = t.CategoryId;



                    command.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
                catch (SqlException e)
                {

                }

            }
        }

        public void Delete(int id)
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
                    command.CommandText = "DeleteOneProduct";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
                catch (SqlException e)
                {

                }

            }
        }

        public Product Read(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                Product product = new Product();
                con.ConnectionString = @"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;";

                SqlCommand command = new SqlCommand("GetOneProduct", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    product = new Product();
                    product.Id = int.Parse(reader["ID"].ToString());
                    product.ProductName = reader["productName"].ToString();
                    product.Price = reader["price"].ToString();
                    product.Information = reader["information"].ToString();
                    product.Manufacture = reader["manufacture"].ToString();
                    product.CategoryId = int.Parse(reader["categoryId"].ToString());


                }
                con.Close();
                con.Dispose();
                return product;
            }
        }

        public List<Product> ReadAll()
        {
            using (SqlConnection con = new SqlConnection())
            {
                
                Product product;
                Task<List<Product>> data =  tj.GetDataFromReader("GetAllProducts");
                List<Product> ProductList = data.Result;                  
                return  ProductList;
            }
        }
        
        
        public void Update(Product t)
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
                    command.CommandText = "UpdateOneProduct";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = t.Id;
                    command.Parameters.Add("@productName", SqlDbType.NVarChar, 50).Value = t.ProductName;
                    command.Parameters.Add("@price", SqlDbType.NVarChar, 50).Value = t.Price;
                    command.Parameters.Add("@information", SqlDbType.NVarChar).Value = t.Information;
                    command.Parameters.Add("@manufacture", SqlDbType.NVarChar, 50).Value = t.Manufacture;
                    command.Parameters.Add("@categoryId", SqlDbType.Int).Value = t.CategoryId;
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
