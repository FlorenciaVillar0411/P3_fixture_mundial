using System;
using System.Collections.Generic;
using System.Linq;
using Excepciones;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.BaseDatos
{
    public class RepositorioPartidoFixture : IRepositorioPartidoFixture
    {


        public LibreriaContext Contexto { get; set; }

        public RepositorioPartidoFixture(LibreriaContext context)
        {
            Contexto = context;
        }

        public void Add(PartidoFixture nuevo)
        {
            try
            {
                nuevo.Validar();
                ValidarPartidos(nuevo);
                Contexto.PartidosFixture.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void ValidarPartidos(PartidoFixture nuevo)
        {
            ValidarPartidosDeSelecciones(nuevo);
            ValidarFechaYHorario(nuevo);
            ValidarGrupo(nuevo);
        }

        private void ValidarFechaYHorario(PartidoFixture nuevo)
        {
            List<PartidoFixture> partidos = Contexto.PartidosFixture.ToList();

            foreach (PartidoFixture p in partidos)
            {
                if (p.Fecha.Date == nuevo.Fecha.Date && p.Hora == nuevo.Hora)
                {
                    throw new PartidoException("Ya existe un partido al mismo tiempo");
                }
            }
        }

        private void ValidarPartidosDeSelecciones(PartidoFixture partido)
        {
            List<PartidoFixture> partidos = Contexto.PartidosFixture.ToList();
            int partidosEquipoUno = 0;
            int partidosEquipoDos = 0;
            foreach (PartidoFixture p in partidos)
            {
                if (p.IdEquipoUno == partido.IdEquipoUno || p.IdEquipoDos == partido.IdEquipoUno)
                {
                    partidosEquipoUno++;
                    if (partidosEquipoUno >= 3)
                    {
                        throw new PartidoException("Seleccion 1 ya tiene 3 partidos asignados");
                    }
                }
                if (p.IdEquipoUno == partido.IdEquipoDos || p.IdEquipoDos == partido.IdEquipoDos)
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

        private void PartidoYaJugado(PartidoFixture partido, PartidoFixture p)
        {
            if (p.IdEquipoUno == partido.IdEquipoUno && p.IdEquipoDos == partido.IdEquipoDos)
            {
                throw new PartidoException("Partido ya ingresado");
            }
            if (p.IdEquipoDos == partido.IdEquipoUno && p.IdEquipoUno == partido.IdEquipoDos)
            {
                throw new PartidoException("Partido ya ingresado");
            }
        }
        private void ValidarGrupo(PartidoFixture partido)
        {
            if(Contexto.Selecciones.Find(partido.IdEquipoUno).IdGrupo != Contexto.Selecciones.Find(partido.IdEquipoUno).IdGrupo)
            {
                throw new PartidoException("Selecciones no pertencen al mismo grupo");
            }
        }

        public void AgregarResultados(PartidoFixture partido)
        {
            try
            {
                Contexto.PartidosFixture.Update(partido);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede agregar resultados", e);
            }
        }

        public IEnumerable<PartidoFixture> FindAll()
        {
            return Contexto.PartidosFixture.ToList();
        }

        public PartidoFixture FindById(int id)
        {
            return Contexto.PartidosFixture.Find(id);
        }

        public void Remove(int id)
        {
            try
            {
                PartidoFixture aBorrar = Contexto.PartidosFixture.Find(id);
                Contexto.PartidosFixture.Remove(aBorrar);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede eliminar el Partido", e);
            }
        }

        public void Update(PartidoFixture partido)
        {
            try
            {
                Contexto.PartidosFixture.Update(partido);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede editar el Partido", e);
            }
        }

        public IEnumerable<PartidoFixture> PorGrupo(string g)
        {
            IEnumerable<Seleccion> selecciones = Contexto.Selecciones.Include(x => x.Grupo).ToList();
            IEnumerable<Seleccion> selecciones2 =  selecciones.Where(t => t.Grupo.Nombre == g);
            IEnumerable<PartidoFixture> partidos = Contexto.PartidosFixture.ToList();
            foreach (Seleccion s in selecciones2)
            {
                partidos = partidos.Where(par => par.IdEquipoUno != s.Id);               
            }           
            return partidos;
        }
        public IEnumerable<Resultado> PorGrupoResultado(string g)
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

        public IEnumerable<Tarjeta> VerTarjetas(int id)
        {
            IEnumerable<Tarjeta> tarjetas = Contexto.Tarjetas.Include(x => x.Partido).Include(x => x.Seleccion).ToList();
            return tarjetas.Where(t => t.PartidoId == id);
        }

        public int Goles(int id)
        {
            throw new NotImplementedException();
        }

        public int Puntaje(int id)
        {
            throw new NotImplementedException();
        }
    }
}
