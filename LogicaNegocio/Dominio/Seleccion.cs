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
        [MinLength(1), MaxLength(25), Required(ErrorMessage = "Nombre es obligatorio")]
        public string Nombre { get; set; }
     
        public string Email { get; set; }
        [MinLength(7), Required(ErrorMessage = "Telefono debe tener al menos 7 caracteres numericos")]
        public string Telefono { get; set; }
       
        public int CantidadApostadores { get; set; }
        public Grupo Grupo { get; set; }

        public void Validar()
        {
            ValidarNombres();
            ValidarUnaSeleccionPorPais(); //VEEEEEEEEEEEEEEEEEER
            ValidarNombreContacto();
            ValidarEmail();
            ValidarNumeroTelefono();
            ValidarCantidadesApostadoresPostiivas();
        }
        public void ValidarNombres()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new SeleccionException("Seleccion debe tener un nombre valido");
            }
        }
        //VEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEER
        public void ValidarUnaSeleccionPorPais()
        {
           
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
        public bool ValidarEmail()
        {
            String expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(Email, expresion))
            {
                if (Regex.Replace(Email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public void ValidarNumeroTelefono()
        {
            if(Telefono.Length > 7)
            {
                for (int i = 0; i < Telefono.Length; i++)
                {
                    char numero = Telefono[i];
                    if (!Char.IsNumber(numero))
                    {
                        throw new SeleccionException("Nombre no valido");
                    }
                }
            }
            else
            {
                throw new SeleccionException("Nombre no valido");
            }
          
        }
        public void ValidarCantidadesApostadoresPostiivas()
        {
            if(CantidadApostadores < 0)
            {
                throw new SeleccionException("La cantidad de apostadoresdebe ser mayor a cero");
            }
        }
    }
}
