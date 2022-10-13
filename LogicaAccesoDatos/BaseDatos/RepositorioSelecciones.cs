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
                ValidarGrupo(obj);
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
            IEnumerable<Seleccion> selecciones = Contexto.Selecciones.Include(s => s.Pais).ToList();
            foreach (Seleccion s in selecciones)
            {
                if (s.Pais.Id == nuevo.PaisId)
                {
                    throw new SeleccionException("Pais ya tiene seleccion");
                }
            }
        }
        private void ValidarGrupo(Seleccion nuevo)
        {
            IEnumerable<Grupo> grupos = Contexto.Grupos.ToList();
            foreach (Grupo g in grupos)
            {
                if (g.Id == nuevo.IdGrupo)
                {
                    g.Validar();
                }
            }
        }

        public IEnumerable<Seleccion> FindAll()
        {
            return Contexto.Selecciones.Include(s => s.Pais).Include(s => s.Grupo).ToList();
        }

        public Seleccion FindById(int id)
        {
            try
            {
                Seleccion buscada = Contexto.Selecciones.Find(id);
                Pais pais = Contexto.Paises.Find(buscada.PaisId);
                Grupo grupo = Contexto.Grupos.Find(buscada.IdGrupo);
                buscada.Pais = pais;
                buscada.Grupo = grupo;
                return buscada;
            }
            catch (Exception e)
            {
                throw new SeleccionException(e.Message);
            }
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
            catch(Exception e)
            {
                throw new SeleccionException(e.Message);
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
            catch (Exception ex)
            {
                throw new SeleccionException(ex.Message);
            }
        }
        public int Goles(Seleccion obj)
        {
            int goles = 0;
            List<Resultado> partidos = Contexto.Resultados.Include(r => r.Partido).ToList();
            foreach (Resultado p in partidos)
            {
                if (p.Partido.IdEquipoUno == obj.Id)
                {
                    goles += p.CantidadGolesEquipoUno;
                }
                if (p.Partido.IdEquipoDos == obj.Id)
                {
                    goles += p.CantidadGolesEquipoDos;
                }
            }
            return goles;
        }
        public int Puntaje(Seleccion obj)
        {
            int puntaje = 0;
            List<Resultado> partidos = Contexto.Resultados.Include(r => r.Partido).ToList();
            foreach (Resultado p in partidos)
            {
                if (p.Partido.IdEquipoUno == obj.Id)
                {
                    puntaje += p.PuntajeEquipoUno;
                }
                if (p.Partido.IdEquipoDos == obj.Id)
                {
                    puntaje += p.PuntajeEquipoDos;
                }
            }
            return puntaje;
        }
        public IEnumerable<Tarjeta> VerTarjetas(int id)
        {
            IEnumerable<Tarjeta> tarjetas =  Contexto.Tarjetas.Include(x => x.Partido).ToList();
            return tarjetas.Where(t => t.PartidoId == id);

        }

        public void ValidarEliminacion(Seleccion aBorrar)
        {
            if(aBorrar == null)
            {
                List<PartidoFixture> partidos = Contexto.PartidosFixture.ToList();
                foreach (PartidoFixture p in partidos)
                {
                    if (p.IdEquipoUno == aBorrar.Id || p.IdEquipoDos == aBorrar.Id)
                    {
                        throw new SeleccionException("Seleccion tiene partidos asignados");
                    }
                }
            }
        }
    }
}
