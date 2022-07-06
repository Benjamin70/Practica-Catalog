using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidad
{
    public partial class Product
    {
        public int Id_Product { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int CategoryID { get; set; }
    }
}
