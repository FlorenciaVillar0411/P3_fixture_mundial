using Excepciones;
using LogicaNegocio;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.Dominio
{
    [Table("Selecciones")]
    public class Seleccion : IValidacion
    {
        public int Id { get; set; }
        public Pais Pais { get; set; }
        [MinLength(1), MaxLength(25), Required(ErrorMessage = "Nombre es obligatorio")]

        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int CantidadApostadores { get; set; }
        public Grupo Grupo { get; set; }

        public void Validar()
        {
            ValidarNombres();
        }
        public void ValidarNombres()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new SeleccionException("Seleccion debe tener un nombre valido");
            }

        }
    }
}
