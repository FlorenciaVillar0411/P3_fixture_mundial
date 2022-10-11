using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            return Contexto.Paises.Find(id);
        }

        public Pais FindPaisByCodigo(string codigo)
        {
            return Contexto.Paises.Find(codigo);
        }

        public IEnumerable<Pais> GetPaisesByRegion(Region region)
        {
            return Contexto.Paises.Where(x => x.Region == region);
        }

        public void Remove(int id)
        {
            try
            {
                Pais aBorrar = Contexto.Paises.Find(id);
                Contexto.Paises.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Update(Pais modificado)
        {
            try
            {
                Contexto.Update(modificado);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public bool ValidarEliminacion()
        {
            throw new NotImplementedException();
        }
    }
}
