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
    public class CategoryConnector : IConnector<Category>
    {
        public void Create(Category t)
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
                    command.CommandText = "CreateCategory";
                    command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = t.CategoryName;
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
                    command.CommandText = "DeleteOneCategory";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    command.ExecuteNonQuery();
                    sqlConnection1.Close();
                }
                catch (SqlException e)
                {

                }

            }
        }

        public Category Read(int id)
        {
            using (SqlConnection con = new SqlConnection())
            {
                Category category = new Category();
                con.ConnectionString = @"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;";

                SqlCommand command = new SqlCommand("GetOneCategory", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                SqlDataReader reader = command.ExecuteReader();



                while (reader.Read())
                {
                    category = new Category();
                    category.Id = int.Parse(reader["ID"].ToString());
                    category.CategoryName = reader["category"].ToString();


                }
                con.Close();
                con.Dispose();
                return category;
            }
        }

        public List<Category> ReadAll()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;";
                con.Open();
                SqlCommand command = new SqlCommand("GetAllCategories", con);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();

                List<Category> categoryList = new List<Category>();
                Category category;

                while (reader.Read())
                {
                    category = new Category
                    {
                        Id = int.Parse(reader["id"].ToString()),
                        CategoryName = reader["category"].ToString(),


                    };
                    categoryList.Add(category);

                }
                return categoryList;
            }
        }

        public void Update(Category t)
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
                    command.CommandText = "UpdateOneCategory";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = t.Id;
                    command.Parameters.Add("@category", SqlDbType.NVarChar, 50).Value = t.CategoryName;
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
