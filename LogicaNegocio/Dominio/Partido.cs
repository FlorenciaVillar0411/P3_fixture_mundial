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
        public int IdEquipoUno { get; set; }
        public int IdEquipoDos { get; set; }
        public DateTime Fecha { get; set; }

        public int Hora { get; set; }
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
            ValidarFechas();
            ValidarHora();
            ValidarEquipos();

        }
        public void ValidarResultado()
        {
            ValidarFechas();
            ValidarHora();
            ValidarEquipos();
            ValidarPositivos();
        }

        private void ValidarPositivos()
        {
            if (CantidadGolesEquipoUno < 0 || CantidadGolesEquipoDos < 0 || PuntajeEquipoUno < 0 || PuntajeEquipoDos < 0)
            {
                throw new PartidoException("Resultados deben ser validos");
            }
        }

        private void ValidarEquipos()
        {
            if (IdEquipoUno ==IdEquipoDos)
            {
                throw new PartidoException("Seleccion no puede jugar contra si misma");
            }
            //if (IdEquipoUno.Grupo.Id != EquipoDos.Grupo.Id)
            //{
            //    throw new PartidoException("Seleccion no puede jugar contra si misma");
            //}
        }

        private void ValidarHora()
        {
            if (Hora == 7 || Hora == 10 || Hora == 13 || Hora ==16)
            {
                throw new PartidoException("Horario inavlido");
            }
        }

        void ValidarFechas()
        {
            DateTime fechaFaseInicio = new DateTime(20 / 11 / 2022);
            DateTime fechaFaseFinal = new DateTime(02 / 12 / 2022);

            if (Fecha < fechaFaseInicio || Fecha < fechaFaseFinal)
            {
                throw new PartidoException("Fechas inavlidas");
            }
        }
    }
}
