using LogicaNegocio.InterfacesDominio;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogicaNegocio
{
    public class Rol: IValidacion
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public void Validar()
        {
            ValidarRol();
        }

        private void ValidarRol()
        {
            if(Nombre == "Admin")
            {
                Descripcion = "Acceso a todas las funcionalidades sin excepcion";
            } else if(Nombre == "Apostador")
            {
                Descripcion = "Acceso a las busquedas y a obtener un grupo con su fixture";

            }
            else if (Nombre == "Invitado")
            {
                Descripcion = "Acceso a fixture, buscar una seleccion y al listado de todas las selecciones";
            }
            else
            {
                throw new Exception("Usuario no tiene Rol");
            }
        }
    }
}
