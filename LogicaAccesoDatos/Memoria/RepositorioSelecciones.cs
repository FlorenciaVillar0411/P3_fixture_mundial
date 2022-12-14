using System;
using System.Collections.Generic;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioSelecciones : IRepositorioSelecciones
    {
        public static List<Seleccion> Selecciones { get; set; } = new List<Seleccion>();
        public static int UltimoId { get; set; }


        public void Add(Seleccion nuevo)
        {
            nuevo.Validar();
            nuevo.Id = ++UltimoId;
            Selecciones.Add(nuevo);
        }

        public IEnumerable<Seleccion> FindAll()
        {
            return Selecciones;
        }

        public IEnumerable<Seleccion> FindByGroup(string nomGrupo)
        {
            throw new NotImplementedException();
        }

        public Seleccion FindById(int id)
        {
            return Selecciones.Find(x => x.Id == id);
        }

        public int Goles(Seleccion seleccion)
        {
            throw new NotImplementedException();
        }

        public int GolesEnContra(Seleccion seleccion)
        {
            throw new NotImplementedException();
        }

        public int Puntaje(Seleccion obj)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            Seleccion aBorrar = Selecciones.Find(x => x.Id == id);
            Selecciones = Selecciones.FindAll(x => x != aBorrar);
        }

        public void Update(Seleccion obj)
        {
            int aModificar = Selecciones.FindIndex(x => x.Id == obj.Id);
            Selecciones[aModificar] = obj;
        }


        public void ValidarEliminacion(Seleccion seleccion)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tarjeta> VerTarjetas(int id)
        {
            throw new NotImplementedException();
        }
    }
}
