using Excepciones;
using LogicaNegocio;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.RegularExpressions;

namespace LogicaNegocio.Dominio
{
    [Table("Selecciones")]
    public class Seleccion : IValidacion
    {
        public int Id { get; set; }
        public Pais Pais { get; set; }
        [ForeignKey("Pais")]
        public int IdPais { get; set; }
        [MinLength(1), MaxLength(25), Required(ErrorMessage = "Nombre es obligatorio")]
        public string Nombre { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int CantidadApostadores { get; set; }
        public Grupo Grupo { get; set; }
        [ForeignKey("Grupo")]
        public int IdGrupo { get; set; }



        public void Validar()

        {
 
            if (Nombre == "")
            {
                throw new PaisException("Nombre vacio");
            }

            for (int i = 0; i < Nombre.Length; i++)
            {
                char caracter = Nombre[i];
                if (Char.IsNumber(caracter))
                {
                    throw new PaisException("Nombre no valido");
                }
            }
            
        }
        public void ValidarNombreContacto()
        {
            if (Nombre == "")
            {
                throw new PaisException("Nombre vacio");
            }

            for (int i = 0; i < Nombre.Length; i++)
            {
                char caracter = Nombre[i];
                if (Char.IsNumber(caracter))
                {
                    throw new SeleccionException("Nombre no valido");
                }
            }
        }
        public void ValidarEmail()
        {
            if (!Email.Contains("@"))
            {
                throw new SeleccionException("mail invalido");
            }           
        }
        public void ValidarNumeroTelefono()
        {
            if(Telefono.Length < 7)
            {
                throw new SeleccionException("Numero debe tener 7 digitos");
            }          
        }
        public void ValidarCantidadesApostadoresPostiivas()
        {
            if(CantidadApostadores <= 0)
            {
                throw new SeleccionException("La cantidad de apostadoresdebe ser mayor a cero");
            }
        }
    }
}
