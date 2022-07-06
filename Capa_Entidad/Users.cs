using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Capa_Entidad
{
    public partial  class Users
    {
        public int Id_User { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public int Registered { get; set; }

        public bool Comprobation { get; set; }

        public string Messages { get; set; }
    }
}
