using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos.BaseDatos
{

    public class RepositorioPaises : IRepositorioPaises
    {
        //public LibreriaContext Contexto { get; set; }

        //public RepositorioPaises(LibreriaContext ctx)
        //{
        //    Contexto = ctx;
        //}
        public void Add(Pais obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> FindAll()
        {
            throw new NotImplementedException();
        }

        public Pais FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Pais FindPaisByCodigo(string codigo)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pais> GetPaisesByRegion(Region region)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }

        public bool ValidarEliminacion()
        {
            throw new NotImplementedException();
        }
    }
}
