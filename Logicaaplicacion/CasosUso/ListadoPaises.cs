using System;
using System.Collections.Generic;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class ListadoPaises: IListadoPaises
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public ListadoPaises(IRepositorioPaises repoPaises)
        {
            RepoPaises = repoPaises;
        }

        public IEnumerable<Pais> ObtenerListado()
        {
            return RepoPaises.FindAll();
        }
    }
}
