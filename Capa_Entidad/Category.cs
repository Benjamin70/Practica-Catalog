using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Capa_Entidad
{
    public partial class Category
    {
        [Key]
        public int Id_Category { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Description { get; set; }
    }
}
