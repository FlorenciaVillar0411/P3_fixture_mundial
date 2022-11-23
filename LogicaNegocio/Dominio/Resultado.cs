using Excepciones;
using LogicaNegocio.InterfacesDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LogicaNegocio.Dominio
{
    public class Resultado : IValidacion
    {
        public int Id { get; set; }
        public PartidoFixture Partido { get; set; }
        [ForeignKey("Partido")]
        public int IdPartido { get; set; }

        [Display(Name = "Goles seleccion 1")]
        public int CantidadGolesEquipoUno { get; set; }
        [Display(Name = "Goles seleccion 2")]
        public int CantidadGolesEquipoDos { get; set; }
        [Display(Name = "Puntos seleccion 1")]
        public int PuntajeEquipoUno { get; set; }
        [Display(Name = "Puntos seleccion 2")]
        public int PuntajeEquipoDos { get; set; }

        public void Validar()
        {
            ValidarPositivos();
        }
        private void ValidarPositivos()
        {
            if (CantidadGolesEquipoUno < 0 || CantidadGolesEquipoDos < 0 || PuntajeEquipoUno < 0 || PuntajeEquipoDos < 0)
            {
                throw new PartidoException("Resultados deben ser validos");
            }
        }
    }
}
