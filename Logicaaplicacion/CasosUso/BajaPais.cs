using System;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class BajaPais: IBajaPais
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public BajaPais(IRepositorioPaises repo)
        {
            RepoPaises = repo;
        }

        public void Baja(int id)
        {
            RepoPaises.Remove(id);
        }
    }
}
