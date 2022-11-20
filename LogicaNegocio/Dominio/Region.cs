using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.Dominio
{
    [Table("Regiones")]
    public class Region : IValidacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void Validar()
        {
            ValidarNombre();
        }

        public void ValidarNombre()
        {
            string[] regiones = new string[]
            {
                "africa",
                "america",
                "asia",
                "europa",
                "oceania"
            };

             if (!regiones.ToString().Contains(Nombre))
            {
                throw new Exception("La region debe tener un nombre valido");
            }
        }
    }


    
}
   
       
