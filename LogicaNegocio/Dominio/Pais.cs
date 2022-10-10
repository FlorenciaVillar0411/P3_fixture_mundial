using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;
using System.Diagnostics.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using Excepciones;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio.Dominio
{
    [Table("Paises")]
    public class Pais : IValidacion, IComparable<Pais>
    {
        public int Id { get; set; }
        [MinLength(1), MaxLength(25), Required(ErrorMessage ="Nombre es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name ="Codigo ISO Alfa 3"), Required(ErrorMessage ="Codigo es obligatorio")]
        public string CodigoISOAlfa3 { get; set; }
        [Required(ErrorMessage = "Pbi es obligatorio")]

        public double Pbi { get; set; }
        public int Poblacion { get; set; }

        public string Imagen { get; set; }
        [Required]
        public Region Region { get; set; }
        [ForeignKey("Pais")]
        public int RegionId { get; set; }


        public void Validar()
        {
            ValidarCodigo(CodigoISOAlfa3, Nombre);
            ValidarNombre(Nombre);
        }

        public void ValidarCodigo(string CodigoISOAlfa3, string Nombre)
        {
            char primeraLetra = Nombre[0];
            if (CodigoISOAlfa3.Length < 3 && CodigoISOAlfa3.Length > 3 && !CodigoISOAlfa3.StartsWith(primeraLetra))
            {
                throw new PaisException("El codigo no es valido");
            }
        }
        public void ValidarNombre(string nombre)
        {
            if (nombre == "")
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

        public int CompareTo([AllowNull] Pais other)
        {
            throw new NotImplementedException();
        }
    }
}
