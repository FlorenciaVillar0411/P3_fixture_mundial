using Excepciones;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioResultado : IRepositorioResultado
    {
        public LibreriaContext Contexto { get; set; }
        public RepositorioResultado(LibreriaContext ctx)
        {
            Contexto = ctx;
        }
        public void Add(Resultado nuevo)
        {
            try
            {
                nuevo.Validar();
                Contexto.Resultados.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede agregar el partido", e);
            }
        }

        public IEnumerable<Resultado> FindAll()
        {
            return Contexto.Resultados.Include(r => r.Partido).ToList();
        }

        public Resultado FindById(int id)
        {
            try
            {
                IEnumerable<Resultado> resultados = Contexto.Resultados.Include(p => p.Partido).ToList();
                foreach (Resultado p in resultados)
                {
                    if (p.IdPartido == id)
                    {
                        return p;
                    }
                }
                throw new PartidoException("No se encontro");
            }
            catch (Exception e)
            {
                throw new PartidoException(e.Message);
            }
        }

        public void Remove(int id)
        {
            try
            {
                Resultado aBorrar = Contexto.Resultados.Find(id);
                Contexto.Resultados.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede eliminar el Resultado", e);
            }
        }

        public void Update(Resultado obj)
        {
            try
            {
                Contexto.Resultados.Update(obj);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede editar el Partido", e);
            }
        }
        public IEnumerable<Resultado> PorGrupo(string g)
        {
            IEnumerable<Seleccion> selecciones = Contexto.Selecciones.Include(x => x.Grupo).ToList();
            IEnumerable<Seleccion> selecciones2 = selecciones.Where(t => t.Grupo.Nombre == g);
            IEnumerable<Resultado> partidos = Contexto.Resultados.Include(x => x.Partido).ToList();
            foreach (Seleccion s in selecciones2)
            {
                partidos = partidos.Where(par => par.Partido.IdEquipoUno != s.Id);
            }
            return partidos;
        }
    }
}
