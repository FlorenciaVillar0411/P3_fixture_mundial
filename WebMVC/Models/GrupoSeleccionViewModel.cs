using LogicaNegocio.Dominio;
using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class GrupoSeleccionViewModel
    {
        public IEnumerable<Grupo> Grupos { get; set; }
        public string NombreGrupo { get; set; }
        public IEnumerable<DTOSeleccion> Selecciones { get; set; }
        public int IdSeleccion { get; set; }

    }
}
