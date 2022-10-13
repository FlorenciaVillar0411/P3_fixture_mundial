using LogicaNegocio.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPartidoFixture : IRepositorio<PartidoFixture>
    {
        public IEnumerable<PartidoFixture>PorGrupo(string grupo);
        public int Goles(int id );
        public IEnumerable<Tarjeta> VerTarjetas(int id);
        public int Puntaje(int id);

    }
}
