using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioSelecciones : IRepositorioSelecciones
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
                obj.Validar();
                ValidarUnicaPorPais(obj);
                Contexto.Selecciones.Add(obj);
                Contexto.SaveChanges();
            }
            catch(Exception ex )
            {
                throw new SeleccionException(ex.Message);
            }
        }

        private void ValidarUnicaPorPais(Seleccion nuevo)
        {
            List<Seleccion> selecciones = Contexto.Selecciones.Include(s => s.Pais).ToList();
            foreach (Seleccion s in selecciones)
            {
                if (s.Pais == nuevo.Pais)
                {
                    throw new SeleccionException("Pais ya tiene seleccion");
                }
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
                ValidarEliminacion(aBorrar);
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
                obj.Validar();
                Contexto.Selecciones.Update(obj);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void ValidarEliminacion(Seleccion aBorrar)
        {
            List<Partido> partidos = Contexto.Partidos.Include(p => p.EquipoUno).ToList();
            foreach (Partido p in partidos)
            {
                if (p.EquipoUno == aBorrar || p.EquipoDos == aBorrar)
                {
                    throw new SeleccionException("Seleccion tiene partidos asignados");
                }
            }
        }
    }
}
