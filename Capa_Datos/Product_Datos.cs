using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data.SqlClient;
using System.Data;



namespace Capa_Datos
{
    public class Product_Datos
    {
        string conString = ConfigurationManager.ConnectionStrings["AdoConnectionStrings"].ToString();
        
        //GetAllProduct
        public List<Product> GetAllProduct()
        {
            List<Product> productsList = new List<Product>();
            using(SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllProduct";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProduct = new DataTable();

                connection.Open();
                sqlDA.Fill(dtProduct);
                connection.Close();

                foreach(DataRow dr in dtProduct.Rows)
                {
                    productsList.Add(new Product
                    {
                        Id_Product = Convert.ToInt32(dr["Id_Product"]),
                        Name = dr["Name"].ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        CategoryID = Convert.ToInt32(dr["CategoryID"])
                    });
                }
            }

            return productsList;
        }

        //GetInsertProducts
        public bool InserterProduct(Product product)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //GetProductByID
        public List<Product> GetProductsByID(int? Id_Product)
        {
            List<Product> productsList = new List<Product>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetProductByID";
                command.Parameters.AddWithValue("@Id_Product", Id_Product);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtProduct = new DataTable();

                connection.Open();
                sqlDA.Fill(dtProduct);
                connection.Close();

                foreach (DataRow dr in dtProduct.Rows)
                {
                    productsList.Add(new Product
                    {
                        Id_Product = Convert.ToInt32(dr["Id_Product"]),
                        Name = dr["Name"].ToString(),
                        Price = Convert.ToDecimal(dr["Price"]),
                        CategoryID = Convert.ToInt32(dr["CategoryID"])
                    });
                }
            }
            return productsList;
        }

        //UpdateProduct
        public bool UpdateProduct(Product product)
        {
            int id = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateProducts", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_Product", product.Id_Product);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@CategoryID", product.CategoryID);
                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if (id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //DeleteProduct
        public bool DeleteCategory(int Id_Product)
        {
            int o = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_DeleteProduct", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_Product", Id_Product);
                connection.Open();
                o = command.ExecuteNonQuery();
                connection.Close();
            }
            if (o > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
