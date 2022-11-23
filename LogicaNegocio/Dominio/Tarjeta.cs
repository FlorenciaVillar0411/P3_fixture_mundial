using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.Dominio
{
    [Table("Tarjetas")]
    public class Tarjeta
    {
        public int Id { get; set; }
        [MinLength(3), MaxLength(25), Required(ErrorMessage = "Color es obligatorio")]
        public string Color { get; set; }
        public Seleccion Seleccion { get; set; }
        [ForeignKey("Seleccion")]
        public int SeleccionId { get; set; }

        public PartidoFixture Partido { get; set; }
        [ForeignKey("Partido")]
        public int PartidoId { get; set; }


    }
}
