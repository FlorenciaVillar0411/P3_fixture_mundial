using System;
using System.Collections.Generic;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioSelecciones : IRepositorioSelecciones
    {
        public static List<Seleccion> selecciones { get; set; } = new List<Seleccion>();

        public void Add(Seleccion obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seleccion> FindAll()
        {
            throw new NotImplementedException();
        }

        public Seleccion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Seleccion obj)
        {
            throw new NotImplementedException();
        }

        public bool ValidarEliminacion()
        {
            throw new NotImplementedException();
        }
    }
}
