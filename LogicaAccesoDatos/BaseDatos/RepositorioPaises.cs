﻿using System;
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
            catch (Exception e)
            {
                throw new Exception("No se puede agregar el Pais", e);
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
            catch (Exception e)
            {
                throw new Exception("No se puede eliminar el Pais", e);
            }
        }

        public void Update(Pais modificado)
        {
            try
            {
                Contexto.Update(modificado);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede editar el Pais", e);
            }
        }

        public bool ValidarEliminacion()
        {
            throw new NotImplementedException();
        }
    }
}
