using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.Dominio
{
    [Table("Grupos")]
    public class Grupo : IValidacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [MinLength(1), MaxLength(25), Required(ErrorMessage = "Nombre es obligatorio")]
        public Fase Fase { get; set; }
        [ForeignKey("Fase")]
        public int FaseId { get; set; }



        public void Validar()
        {
            ValidarNombre();
        }

        private void ValidarNombre()
        {
            if (Nombre =="A" || Nombre == "B" || Nombre == "C" || Nombre == "D" || Nombre == "E" || Nombre == "F" || Nombre == "G" || Nombre == "H")
            {
            } else
            {
                throw new NotImplementedException();
            }
        }
    }
}
