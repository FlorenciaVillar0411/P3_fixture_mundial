using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Dominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioSelecciones: IRepositorio<Seleccion>
    {
        void ValidarEliminacion(Seleccion seleccion);
        public int Goles(Seleccion seleccion);
        public int GolesEnContra(Seleccion seleccion);
        public IEnumerable<Tarjeta> VerTarjetas(int id);
        public int Puntaje(Seleccion obj);

        public IEnumerable<Seleccion> FindByGroup(string nomGrupo);

    }
}
