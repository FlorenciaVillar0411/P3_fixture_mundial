﻿using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class PaisViewModel
    {
        public IEnumerable<Region> Regiones{ get; set; }
        public Pais Nuevo { get; set; }
        public int IdRegion { get; set; }
}
}
