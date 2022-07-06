using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidad;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace Capa_Datos
{
    public class Users_Datos
    {
        string conString = ConfigurationManager.ConnectionStrings["AdoConnectionStrings"].ToString();
        
        public List<Users> GetUsers()
        {
            List<Users> usersList = new List<Users>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllUsers";
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtusers = new DataTable();

                connection.Open();
                sqlDA.Fill(dtusers);
                connection.Close();

                foreach (DataRow dr in dtusers.Rows)
                {
                    usersList.Add(new Users
                    {
                        Id_User = Convert.ToInt32(dr["Id_User"]),
                        Email = dr["Email"].ToString(),
                        Password = dr["Password"].ToString()
                    });
                }
            }
            return usersList;
        }

        public List<Users> GetUsersByID(int? Id_User)
        {
            List<Users> usersList = new List<Users>();
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sp_GetAllUsersByID";
                command.Parameters.AddWithValue("@Id_User", Id_User);
                SqlDataAdapter sqlDA = new SqlDataAdapter(command);
                DataTable dtuser = new DataTable();

                connection.Open();
                sqlDA.Fill(dtuser);
                connection.Close();

                foreach (DataRow dr in dtuser.Rows)
                {
                    usersList.Add(new Users
                    {
                        Id_User = Convert.ToInt32(dr["Id_User"]),
                        Email = dr["Email"].ToString(),
                        Password = dr["Password"].ToString()
                    });
                }
            }
            return usersList;
        }

        public bool UpdateUsers(Users users)
        {
            int i = 0;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                SqlCommand command = new SqlCommand("sp_UpdateUsers", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_User", users.Id_User);
                command.Parameters.AddWithValue("@Email", users.Email);
                command.Parameters.AddWithValue("@Password", users.Password);
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

        public void Login_Users(Users user)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {

                try
                {
                    SqlCommand command = new SqlCommand("sp_Access", connection);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.Add("@Comprobation", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();
                    user.Comprobation = Convert.ToBoolean(command.Parameters["@Comprobation"].Value);
                }
                catch (SqlException)
                {
                    user.Messages = "Existe un error, Compruebe usuario y campos";
                }

            }
        }

        public void Check_Users(Users user)
        {
            using (SqlConnection connection = new SqlConnection(conString))
            {

                try
                {
                    SqlCommand command = new SqlCommand("sp_ValidarAccess", connection);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    command.ExecuteNonQuery();
                    user.Id_User = Convert.ToInt32(command.ExecuteScalar().ToString());
                }
                catch(SqlException)
                {
                    user.Messages = "Complete todos los campos";
                }
                

            }
        }
    }
}
