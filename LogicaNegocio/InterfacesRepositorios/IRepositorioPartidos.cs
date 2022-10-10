using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.Dominio;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioPartidos : IRepositorio<Partido>
    {
        void AgregarResultados(Partido partido);
        IEnumerable<Tarjeta> VerTarjetas(int id);

    }
}
