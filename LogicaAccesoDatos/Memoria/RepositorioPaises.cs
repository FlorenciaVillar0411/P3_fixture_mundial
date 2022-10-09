using LogicaNegocio;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace LogicaAccesoDatos.Memoria
{
    public class RepositorioPaises : IRepositorioPaises
    {
        public static List<Pais> paises { get; set; } = new List<Pais>();
        public static int UltimoId { get; set; }
        public void Add(Pais nuevo)
        {
            nuevo.Validar();
            nuevo.Id = ++UltimoId;
            paises.Add(nuevo);
        }

        public IEnumerable<Pais> FindAll()
        {
            return paises;
        }

        public Pais FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Pais FindPaisByCodigo(string codigo)
        {
            throw new NotImplementedException();

        }

        public IEnumerable<Pais> GetPaisesByRegion(Region region)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Pais obj)
        {
            throw new NotImplementedException();
        }

        public bool ValidarEliminacion()
        {
            throw new NotImplementedException();
        }
    }
}
