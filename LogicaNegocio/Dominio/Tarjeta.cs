using ObligatorioP3;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
    public class Tarjeta
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Color { get; set; }
        public Seleccion Seleccion { get; set; }

    }
}
