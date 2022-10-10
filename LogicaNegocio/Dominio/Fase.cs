using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.Dominio
{
    [Table("Fases")]
    public class Fase
    {
        public int Id { get; set; }
        [MinLength(1), MaxLength(25), Required(ErrorMessage = "Nombre es obligatorio")]

        public string Nombre { get; set; }
        [Display(Name = "Fecha Inicio")]
        public DateTime FechaIncio { get; set; }
        [Display(Name = "Fecha Final")]
        public DateTime FechaFinal { get; set; }
    }
}
