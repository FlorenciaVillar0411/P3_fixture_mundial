using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio
{
    public class Fase
    {
        //flopi estuvo aqui
        public int Id { get; set; }
        public static int UltimoId { get; set; }

        public string Nombre { get; set; }
        public DateTime FechaIncio { get; set; }
        public DateTime FechaFinal { get; set; }
    }
}
