using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Dominio
{
    public class Pais : IValidacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string CodigoISOAlfa3 { get; set; }
        public double Pbi { get; set; }
        public int Poblacion { get; set; }

        public string Imagen { get; set; }
        public Region Region { get; set; }

        public void Validar()
        {
            ValidarNombre();
            ValidarCodigo(CodigoISOAlfa3, Nombre);
            ValidarQueContengaLetras(Nombre);
        }
        public void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre) && !ValidarQueContengaLetras(Nombre))  //comprobar que funcione metodo ValidarQueContengaLetras
            {
                //falta ver lo de los espacios enbebido
                //throw new PaisException("el Pais debe tener un nombre valido")
            }

        }

        public void ValidarCodigo(string CodigoISOAlfa3, string Nombre)
        {
            char primeraLetra = Nombre[0];
            if (CodigoISOAlfa3.Length < 3 && CodigoISOAlfa3.Length > 3 && !CodigoISOAlfa3.StartsWith(primeraLetra))
            {
                //throw PaisException("El codigo no es valido")
            }
        }
        public bool ValidarQueContengaLetras(string Nombre)
        {
            for (int i = 0; i < Nombre.Length; i++)
            {
                //A=65 Z=90 and a=97 z=122
                if ((int)Nombre[i] < 65 || ((int)Nombre[i] > 90
                    && (int)Nombre[i] < 97) || (int)Nombre[i] > 122)
                    return false;
            }
            return true;
        }
        public bool ValidarQueContengaLetra(string Nombre) //fijarse cual si la funcion anterior o esta elegimos usar
        {
            for (int i = 0; i < Nombre.Length; i++)
            {
                char caracter = Nombre[i];
                if (Char.IsNumber(caracter))
                {
                   return false;
                }
            }
            return true;
        }
    }
}
