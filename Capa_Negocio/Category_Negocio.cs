using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class Category_Negocio
    {
        private static Category_Datos category = new Category_Datos();
        public static List<Category> GetCatgory()
        {
            return category.GetAllCategories();
        }
        public static bool InsertCategory(Category cat)
        {
            return category.InserterCategory(cat);
        }

        public static List<Category> GetCategorieByID(int? Id_Category)
        {
            return category.GetCategoriesByID(Id_Category);
        }

        public static bool UpdCategory(Category cat)
        {
            return category.UpdateCategory(cat);
        }

        public static bool DeleCategory(int Id_Category)
        {
             return category.DeleteCategory(Id_Category);
        }
    }
}
