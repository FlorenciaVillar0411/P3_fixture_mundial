using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUsuarios.Models
{
    public class UsuarioViewModel
    {
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Rol { get; set; }

        internal Usuario ValidarDatosLogin()
        {
            throw new NotImplementedException();
        }
    }
}
