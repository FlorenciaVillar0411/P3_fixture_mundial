using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.Dominio
{
    [Table("Grupos")]
    public class Grupo
    {
        public int Id { get; set; }
        [MinLength(1), MaxLength(25), Required(ErrorMessage = "Nombre es obligatorio")]
        public IEnumerable<Partido> Partidos  { get; set; }

        public enum Nombre_Region
        {
            África,
            América,
            Asia,
            Europa,
            Oceanía
        }
        //chequear estooooooo
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



    }
}
