using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioGrupo : IRepositorioGrupo
    {

        public LibreriaContext Contexto { get; set; }

        public RepositorioGrupo(LibreriaContext context)
        {
            Contexto = context;
        }
        public void Add(Grupo obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grupo> FindAll()
        {
            return Contexto.Grupos.ToList();
        }

        public Grupo FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Grupo obj)
        {
            throw new NotImplementedException();
        }
    }
}
