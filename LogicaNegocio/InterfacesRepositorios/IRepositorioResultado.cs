using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioResultado : IRepositorio<Resultado>
    {
        public IEnumerable<Resultado> PorGrupo(string grupo);

    }
}
