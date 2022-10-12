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
            return paises.Find(x => x.Id == id);
        }

        public Pais FindPaisByCodigo(string codigo)
        {
            return paises.Find(x => x.CodigoISOAlfa3 == codigo);

        }

        public IEnumerable<Pais> GetPaisesByRegion(Region region)
        {
            return paises.FindAll(x => x.Region == region);
        }

        public IEnumerable<Pais> GetPaisesByRegion(int region)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            Pais aBorrar = paises.Find(x => x.Id == id);
            paises = paises.FindAll(x => x != aBorrar);
        }

        public void Update(Pais obj)
        {
            int aModificar = paises.FindIndex(x => x.Id == obj.Id);
            paises[aModificar] = obj;
        }

        public bool ValidarEliminacion()
        {
            throw new NotImplementedException();
        }
    }
}
