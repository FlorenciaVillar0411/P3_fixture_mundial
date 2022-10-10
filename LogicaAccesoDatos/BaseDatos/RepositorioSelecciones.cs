using System;
using System.Collections.Generic;
using System.Linq;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.BaseDatos
{
    class RepositorioSelecciones : IRepositorioSelecciones
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioSelecciones(LibreriaContext context)
        {
            Contexto = context;
        }
        public void Add(Seleccion obj)
        {
            try
            {
                Contexto.Selecciones.Add(obj);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Seleccion> FindAll()
        {
            return Contexto.Selecciones.ToList();
        }

        public Seleccion FindById(int id)
        {
            return Contexto.Selecciones.Find(id);
        }

        public void Remove(int id)
        {
            try
            {
                Seleccion aBorrar = Contexto.Selecciones.Find(id);
                Contexto.Selecciones.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Update(Seleccion obj)
        {
            try
            {
                Contexto.Selecciones.Update(obj);
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
