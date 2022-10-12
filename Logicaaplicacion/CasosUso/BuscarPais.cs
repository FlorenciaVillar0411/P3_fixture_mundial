using System;
using System.Collections.Generic;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class BuscarPais : IBuscarPais
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public BuscarPais(IRepositorioPaises repo)
        {
            RepoPaises = repo;
        }

        public Pais Buscar(string codigo)
        {
            return RepoPaises.FindPaisByCodigo(codigo);
        }

        public Pais Buscar(int id)
        {
            return RepoPaises.FindById(id);
        }

        public IEnumerable<Pais> BuscarPorRegion(int region)
        {
            return RepoPaises.GetPaisesByRegion(region);
        }
    }
}
