using LogicaNegocio;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObligatorioP3
{
    public class Seleccion : IValidacion
    {
        public int Id { get; set; }
        public static int UltimoId { get; set; }
        public Pais Pais { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public int CantidadApostadores { get; set; }
        public Grupo Grupo { get; set; }

        public void Validar()
        {
            throw new NotImplementedException();
        }
        public void ValidarNombres()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                //throw new PaisException("el Pais debe tener un nombre valido")
            }

        }
    }
}
