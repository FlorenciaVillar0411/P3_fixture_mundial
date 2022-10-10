using System;
using System.Collections.Generic;
using System.Linq;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
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
                Contexto.Partidos.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void AgregarResultados(Partido partido)
        {
            try
            {
                Contexto.Partidos.Update(partido);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
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
            catch
            {
                throw new NotImplementedException();
            }
        }

        public void Update(Partido partido)
        {
            try
            {
                Contexto.Partidos.Update(partido);
                Contexto.SaveChanges();
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public IEnumerable<Tarjeta> VerTarjetas(int id)
        {
            Partido partido = Contexto.Partidos.Find(id);
            return partido.tarjetas;
        }
    }
}
