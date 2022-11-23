using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class ListadoRegiones : IListadoRegiones
    {
        public IRepositorioRegiones RepoRegiones { get; set; }

        public ListadoRegiones(IRepositorioRegiones repoRegiones)
        {
            RepoRegiones = repoRegiones;
        }

        public IEnumerable<Region> ObtenerListado()
        {
            return RepoRegiones.FindAll();
        }
    }
}
