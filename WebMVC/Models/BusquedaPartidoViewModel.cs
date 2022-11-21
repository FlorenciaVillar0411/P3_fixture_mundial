using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class BusquedaPartidoViewModel
    {
        public IEnumerable<Grupo> Grupos { get; set; }
        public string NombreGrupo { get; set; }
        public IEnumerable<Seleccion> selecciones { get; set; }
        public string NombreSeleccion { get; set; }

        public IEnumerable<Pais> Paises { get; set; }

        public string CodigoPais { get; set; }

        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }

        public IEnumerable<PartidoFixture> Partidos { get; set; }

        public int IdPartido { get; set; }
    }
}
