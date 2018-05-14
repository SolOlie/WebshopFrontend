using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TableJoinner
    {
        public Task<DataSet> GetData(string SqlQuery)
        {

            var oledbstring = @"Provider=SQLOLEDB; Data Source=(Local); Database=WebshopDB; Integrated Security=SSPI; Uid=auth_windows; ";
            var sqlstring = @"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;";
            return Task<DataSet>.Factory.StartNew(() =>
                    {
                        using (var con = new SqlConnection(sqlstring))
                        {
                            con.Open();
                            using (var cmd = new SqlCommand(SqlQuery, con))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                using (var da = new SqlDataAdapter(cmd))
                                {

                                    var ds = new DataSet();
                                    da.Fill(ds);
                                    return ds;
                                }


                            }

                        }
                    });
        }
        public async Task<List<Product>> GetDataFromReader(string SqlQuery)
        {
            var oledbstring = @"Provider=SQLOLEDB; Data Source=(Local); Database=WebshopDB; Integrated Security=SSPI; Uid=auth_windows; ";
            var sqlstring = @"Server = PATRICK-PC; Database = WebshopDB;Integrated Security=true; Uid=auth_windows;";

            using (var con = new SqlConnection(sqlstring))
            {

                using (var cmd = new SqlCommand(SqlQuery, con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Product> ds = new List<Product>();
                    while (await reader.ReadAsync())
                    {
                            Product product = new Product
                            {
                            Id = int.Parse(reader["ID"].ToString()),
                            ProductName = reader["productName"].ToString(),
                            Price = reader["price"].ToString(),
                            Information = reader["information"].ToString(),
                            Manufacture = reader["manufacture"].ToString(),
                            CategoryId = int.Parse(reader["categoryId"].ToString()),
                            Category = reader["category"].ToString()
                        };
                            ds.Add(product);
                        
                    }
                    return ds;


                }

            }

        }
    }
}
