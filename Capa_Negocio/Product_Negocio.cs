using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;
using Capa_Entidad;

namespace Capa_Negocio
{
    public class  Product_Negocio
    {
        private static Product_Datos product = new Product_Datos();

        public static List<Product> GetProduct()
        {
            return product.GetAllProduct();
        }

        public static bool InsertProduct(Product pro)
        {
            return product.InserterProduct(pro);
        }

        public static List<Product> GetProductsByID(int? Id_Product)
        {
            return product.GetProductsByID(Id_Product);
        }

        public static bool UpdateProduct(Product pro)
        {
            return product.UpdateProduct(pro);
        }

        public static bool DeleteProduct(int Id_Product)
        {
            return product.DeleteCategory(Id_Product);
        }
    }
}
