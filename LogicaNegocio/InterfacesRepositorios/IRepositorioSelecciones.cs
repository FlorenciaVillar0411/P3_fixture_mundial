﻿using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Dominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioSelecciones: IRepositorio<Seleccion>
    {
        void ValidarEliminacion(Seleccion seleccion);
        int Goles(Seleccion seleccion);
        public IEnumerable<Tarjeta> VerTarjetas(int id);
        public int Puntaje(Seleccion obj);

    }
}
