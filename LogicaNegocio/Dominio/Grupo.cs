using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Grupo
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public enum Nombre_Region
        {
            África,
            América,
            Asia,
            Europa,
            Oceanía
        }

        public bool ParseEnum<Nombre_Region>(int enumValue, out Nombre_Region valido)
        {
            valido = default(Nombre_Region);
            bool parseado = Enum.IsDefined(typeof(Nombre_Region), enumValue);
            if (parseado)
            {
                valido = (Nombre_Region)Enum.ToObject(typeof(Nombre_Region), enumValue);
            }
            return parseado;
        }

        public IEnumerable<Partido> partidos  { get; set; }


    }
}
