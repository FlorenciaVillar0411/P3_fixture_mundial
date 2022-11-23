using System;
using System.Collections.Generic;
using LogicaNegocio;
using LogicaNegocio.Dominio;

namespace LogicaAplicacion.InterfacesCasosUso
{
    public interface IBuscarPais
    {
        Pais Buscar(string codigo);
        Pais Buscar(int id);
        IEnumerable<Pais> BuscarPorRegion(int region);

    }
}
