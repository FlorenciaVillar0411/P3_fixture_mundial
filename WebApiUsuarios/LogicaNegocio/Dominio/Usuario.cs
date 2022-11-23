using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio
{
    public class Usuario : IValidacion
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
            if(Password.Length < 8)
            {
                throw new Exception("Password corta");
            }
            bool min = false;
            bool may = false;
            bool num = false;
            bool esp = false;

            for (int i = 0; i < Password.Length; i++)
            {
                char c = Password[i];
                if (Char.IsLetter(c) && c.ToString().ToLower() == c.ToString())
                {
                    min = true;
                }
                else if (Char.IsLetter(c) && c.ToString().ToUpper() == c.ToString())
                {
                    may = true;
                }
                else if (Char.IsNumber(c))
                {
                    num = true;
                }
                else if (Password != null && !Password.Contains(".") || !Password.Contains(",") || !Password.Contains("!"))
                {
                    esp = true;
                }
            }

            if (!min || !may || !num || !esp)
            {
                throw new Exception("Password inválida");
            }
        }
    }
}
