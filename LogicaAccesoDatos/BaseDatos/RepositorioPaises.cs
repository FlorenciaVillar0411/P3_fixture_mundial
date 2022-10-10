using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System.Linq;

namespace LogicaAccesoDatos.BaseDatos
{

    public class RepositorioPaises : IRepositorioPaises
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPaises(LibreriaContext context)
        {
            Contexto = context;
        }
        public void Add(Pais nuevo)
        {
            try
            {
                nuevo.Validar();
                Contexto.Paises.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }

        }

        public IEnumerable<Pais> FindAll()
        {
            return Contexto.Paises.ToList();

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
