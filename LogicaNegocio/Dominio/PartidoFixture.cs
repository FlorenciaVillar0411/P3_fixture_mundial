using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Excepciones;
using LogicaNegocio;
using LogicaNegocio.InterfacesDominio;

namespace LogicaNegocio.Dominio
{
    [Table("PartidosFixture")]
    public class PartidoFixture
    {
        public int Id { get; set; }
        public int IdEquipoUno { get; set; }
        public int IdEquipoDos { get; set; }
        public DateTime Fecha { get; set; }
        public int Hora { get; set; }


        public void Validar()
        {
            ValidarFechas();
            ValidarHora();
            ValidarEquipos();
        }

        private void ValidarEquipos()
        {
            if (IdEquipoUno == IdEquipoDos)
            {
                throw new PartidoException("Seleccion no puede jugar contra si misma");
            }
        }

        private void ValidarHora()
        {
            if (Hora == 7 || Hora == 10 || Hora == 13 || Hora == 16)
            {
            } else
            {
                throw new PartidoException("Horario inavlido");

            }
        }

        void ValidarFechas()
        {
            DateTime fechaFaseInicio = new DateTime(20/11/2022);
            DateTime fechaFaseFinal = new DateTime(02/12/2022);

            if (Fecha < fechaFaseInicio || Fecha < fechaFaseFinal)
            {
                throw new PartidoException("Fechas inavlidas");
            }
        }
    }
}

