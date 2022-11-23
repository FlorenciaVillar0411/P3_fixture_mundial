using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioRegiones : IRepositorioRegiones
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioRegiones(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Region nuevo)
        {
            try
            {
                Contexto.Regiones.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede agregar Regiones" , e);
            }
        }

        public IEnumerable<Region> FindAll()
        {
            return Contexto.Regiones.ToList();
        }

        public Region FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Region obj)
        {
            throw new NotImplementedException();
        }
    }
}
