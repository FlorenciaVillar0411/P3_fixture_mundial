using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class PaisRegionModel
    {
        public IEnumerable<Region> Regiones { get; set; }
        public Pais Pais { get; set; }
        public IEnumerable<Pais> Paises { get; set; }
        public int IdRegion { get; set; }

    }
}
