using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Excepciones;
using LogicaNegocio;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Dominio
{
    [Table("Partidos")]

    public class Partido : IValidacion
    {
        public int Id { get; set; }
        [Display(Name = "Seleccion 1")]
        public Seleccion EquipoUno { get; set; }
        [Display(Name = "Seleccion 2")]
        public Seleccion EquipoDos { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }
        [Display(Name = "Goles seleccion 1")]
        public int CantidadGolesEquipoUno { get; set; }
        [Display(Name = "Goles seleccion 2")]
        public int CantidadGolesEquipoDos { get; set; }
        public IEnumerable<Tarjeta> tarjetas { get; set; }
        [Display(Name = "Puntos seleccion 1")]
        public int PuntajeEquipoUno { get; set; }
        [Display(Name = "Puntos seleccion 2")]
        public int PuntajeEquipoDos { get; set; }
        public Fase Fase { get; set; }

        public void Validar()
        {
            ValidarPartido();
        }
        void ValidarPartido()
        {
            if(CantidadGolesEquipoUno<0 || CantidadGolesEquipoDos < 0)
            {
                throw new PartidoException("");
            }
        }

        public List<Tarjeta> GetTarjetas()
        {
            return (List<Tarjeta>)tarjetas;
        }
    }
}
