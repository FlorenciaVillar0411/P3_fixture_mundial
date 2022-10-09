using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Grupo
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public string Nombre  { get; set; } //ToDo poner enum!!!!!!!!

        public IEnumerable<Partido> partidos  { get; set; }


    }

    //HOLAAAAA
}
