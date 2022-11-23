using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAplicacion.CasosUso
{
    public class ListadoGrupos: IListadoGrupos
    {
        public IRepositorioGrupo Repo { get; set; }

        public ListadoGrupos(IRepositorioGrupo repo)
        {
            Repo = repo;
        }

        public IEnumerable<Grupo> ObtenerListado()
        {
            return Repo.FindAll();
        }
    }
}
