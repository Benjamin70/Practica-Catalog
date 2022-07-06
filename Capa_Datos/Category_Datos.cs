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
    public class Category_Datos
    {
        string conString = ConfigurationManager.ConnectionStrings["AdoConnectionStrings"].ToString();
        //GetAllCategory
        public List<Category> GetAllCategories()
        {
            List<Category> categoriesList = new List<Category>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllCategory";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtCategory = new DataTable();

                connection.Open();
                sqlDA.Fill(dtCategory);
                connection.Close();

                foreach(DataRow dr in dtCategory.Rows)
                {
                    categoriesList.Add(new Category
                    {
                        Id_Category = Convert.ToInt32(dr["Id_Category"]),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString()
                    }); 
                }
            }
            return categoriesList;
        }
        //Insert Category
        public bool InserterCategory(Category category)
        {
            int id = 0;
            using(SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_InsertCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Name", category.Name);
                command.Parameters.AddWithValue("@Description", category.Description);
                connection.Open();
                id = command.ExecuteNonQuery();
                connection.Close();
            }
            if(id > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //GetCategoryByID
        public List<Category> GetCategoriesByID(int? Id_Category)
        {
            List<Category> categoriesList = new List<Category>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetCategoryByID";
                command.Parameters.AddWithValue("@Id_Category", Id_Category);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtCategory = new DataTable();

                connection.Open();
                sqlDA.Fill(dtCategory);
                connection.Close();

                foreach (DataRow dr in dtCategory.Rows)
                {
                    categoriesList.Add(new Category
                    {
                        Id_Category = Convert.ToInt32(dr["Id_Category"]),
                        Name = dr["Name"].ToString(),
                        Description = dr["Description"].ToString()
                    });
                }
            }
            return categoriesList;
        }

        //Update Category
        public bool UpdateCategory(Category category)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_Category", category.Id_Category);
                command.Parameters.AddWithValue("@Name", category.Name);
                command.Parameters.AddWithValue("@Description", category.Description);
                connection.Open();
                i = command.ExecuteNonQuery();
                connection.Close();
            }
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Delete Category
        public bool DeleteCategory(int Id_Category)
        {
            int o = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_DeleteCategory", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_Category", Id_Category);
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
