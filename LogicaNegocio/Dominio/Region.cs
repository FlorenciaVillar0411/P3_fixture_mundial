using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.Dominio
{
    [Table("Regiones")]
    public class Region
    {
        public int Id { get; set; }
        public int Nombre { get; set; }

        //       public void ValidarNombre(string NombreContinente, int enumValue, out Nombre_Region valido) //VER QUE ONDAAAAAAaaaaaaaa
        //
        //     {
        //       if (string.IsNullOrEmpty(NombreContinente) && !ParseEnum(enumValue,out valido))
        //     {
        //       //throw new Exception("La region debe tener un nombre valido")
        // }
        //       }

    
    }
}
   
       
