using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio
{
    public class Usuario: IValidacion 
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(8)]
        public string Password { get; set; }

        public Rol Rol { get; set; }
        [ForeignKey("Rol")]
        public int RoliId { get; set; }
        public void Validar()
        {
            ValidarEmail();
            ValidarPassword();

        }

        public void ValidarEmail()
        {
            if (Email != null && !Email.Contains("@"))
            {
                throw new Exception("mail invalido");
            }
        }

        private void ValidarPassword()
        {
            
        }

        
    }
}
