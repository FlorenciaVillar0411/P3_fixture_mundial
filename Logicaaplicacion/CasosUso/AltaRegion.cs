using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class AltaRegion: IAltaRegion
    {
        public IRepositorioRegiones RepoRegiones { get; set; }

        public AltaRegion(IRepositorioRegiones repoRegiones)
        {
            RepoRegiones = repoRegiones;
        }

        public void Alta(Region nuevo)
        {
            RepoRegiones.Add(nuevo);
        }

    }
}
