using System;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class AltaPais: IAltaPais
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public AltaPais(IRepositorioPaises repoPaises)
        {
            RepoPaises = repoPaises;
        }

        public void Alta(Pais nuevo)
        {
            RepoPaises.Add(nuevo);
        }
    }
}
