using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioPartidos: IRepositorioPartidos
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPartidos(LibreriaContext context)
        {
            Contexto = context;
        }

        public void Add(Partido nuevo)
        {
            try
            {
                nuevo.Validar();
                ValidarPartidos(nuevo);
                Contexto.Partidos.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede agregar el partido", e);
            }
        }
        public void ValidarPartidos(Partido nuevo)
        {
            ValidarPartidosDeSelecciones(nuevo);
            ValidarFechaYHorario(nuevo);

        }

        private void ValidarFechaYHorario(Partido nuevo)
        {
            List<Partido> partidos = Contexto.Partidos.Include(p => p.EquipoUno).ToList();

            foreach (Partido p in partidos)
            {
                if (p.Fecha == nuevo.Fecha && p.Hora == nuevo.Hora)
                {
                    throw new PartidoException("Ya existe un partido al mismo tiempo");
                }
            }
        }

        private void ValidarPartidosDeSelecciones(Partido partido)
        {
            List<Partido> partidos = Contexto.Partidos.Include(p => p.EquipoUno).ToList();
            int partidosEquipoUno = 0;
            int partidosEquipoDos = 0;
            foreach (Partido p in partidos)
            {
                if (p.EquipoUno == partido.EquipoUno || p.EquipoDos == partido.EquipoUno)
                {
                    partidosEquipoUno++;
                    if (partidosEquipoUno >= 3)
                    {
                        throw new PartidoException("Seleccion 1 ya tiene 3 partidos asignados");
                    }
                }
                if (p.EquipoUno == partido.EquipoDos || p.EquipoDos == partido.EquipoDos)
                {
                    partidosEquipoDos++;
                    if (partidosEquipoDos >= 3)
                    {
                        throw new PartidoException("Seleccion 1 ya tiene 3 partidos asignados");
                    }
                }
                PartidoYaJugado(partido, p);
            }
          
        }

        private void PartidoYaJugado(Partido partido, Partido p)
        {
            if (p.EquipoUno == partido.EquipoUno && p.EquipoDos == partido.EquipoDos)
            {
                throw new PartidoException("Partido ya ingresado");
            }
            if (p.EquipoDos == partido.EquipoUno && p.EquipoUno == partido.EquipoDos)
            {
                throw new PartidoException("Partido ya ingresado");
            }
        }

        public void AgregarResultados(Partido partido)
        {
            try
            {
                Contexto.Partidos.Update(partido);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede agregar resultados", e);
            }
        }

        public IEnumerable<Partido> FindAll()
        {
            return Contexto.Partidos.ToList();
        }

        public Partido FindById(int id)
        {
            return Contexto.Partidos.Find(id);
        }

        public void Remove(int id)
        {
            try
            {
                Partido aBorrar = Contexto.Partidos.Find(id);
                Contexto.Partidos.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede eliminar el Partido", e);
            }
        }

        public void Update(Partido partido)
        {
            try
            {
                Contexto.Partidos.Update(partido);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede editar el Partido", e);
            }
        }

        public IEnumerable<Tarjeta> VerTarjetas(int id)
        {
           return Contexto.Tarjetas.Where(x => x.PartidoId == id); ;
        }
    }
}
