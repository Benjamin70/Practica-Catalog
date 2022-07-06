using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class  Users_Negocio
    {
        private static Users_Datos eject = new Users_Datos();
        public static List<Users> GetUsers()
        {
            return eject.GetUsers();
        }
        public static List<Users> GetUser(int? Id)
        {
            return eject.GetUsersByID(Id);
        }
        public static bool UpdUsers(Users user)
        {
            return eject.UpdateUsers(user);
        }
        public static void Login_Users(Users users)
        {
            eject.Login_Users(users);
        }
        public static void Check_Users(Users users)
        {
            eject.Check_Users(users);
        }
    }
}
