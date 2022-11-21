using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class UsuarioViewModel
    {
        public string Rol { get; internal set; }
        public string Usuario { get; internal set; }

        public class ViewModelUsuario
        {
            public string Usuario { get; set; }
            public string Clave { get; set; }
            public string Rol { get; set; }
        }
    }
}
