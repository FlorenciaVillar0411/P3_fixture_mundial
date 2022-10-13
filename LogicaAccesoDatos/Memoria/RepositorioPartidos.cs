using System;
using System.Collections.Generic;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioPartidos: IRepositorioPartidos
    {
        public static List<Partido> Partidos { get; set; } = new List<Partido>();
        public static int UltimoId { get; set; }

        public void Add(Partido nuevo)
        {
            nuevo.Validar();
            nuevo.Id = ++UltimoId;
            Partidos.Add(nuevo);
        }

        public void AgregarResultados(Partido partido)
        {
            int aModificar = Partidos.FindIndex(x => x.Id == partido.Id);
            Partidos[aModificar] = partido;
        }

        public IEnumerable<Partido> FindAll()
        {
            return Partidos;
        }

        public Partido FindById(int id)
        {
            return Partidos.Find(x => x.Id == id);
        }

        public void Remove(int id)
        {
            Partido aBorrar = Partidos.Find(x => x.Id == id);
            Partidos = Partidos.FindAll(x => x != aBorrar);
        }

        public void Update(Partido obj)
        {
            int aModificar = Partidos.FindIndex(x => x.Id == obj.Id);
            Partidos[aModificar] = obj;
        }

        public IEnumerable<Tarjeta> VerTarjetas(int id)
        {
            throw new NotImplementedException();
        }
    }
}
