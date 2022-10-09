using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Dominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPaises : IRepositorio<Pais>
    {
       Pais FindPaisByCodigo(string codigo);
        IEnumerable<Pais> GetPaisesByRegion(Region region);
        Boolean ValidarEliminacion();
    }
}
