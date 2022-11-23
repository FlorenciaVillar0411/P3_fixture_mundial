using System;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosUso
{
    public class ModificarPais: IModificarPais
    {
        public IRepositorioPaises RepoPaises { get; set; }

        public ModificarPais(IRepositorioPaises repoPaises)
        {
            RepoPaises = repoPaises;
        }

        public void Modificar(Pais nuevo)
        {
            RepoPaises.Update(nuevo);
        }

    }
}
