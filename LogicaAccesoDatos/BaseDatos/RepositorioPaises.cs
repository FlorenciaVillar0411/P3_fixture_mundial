using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Dominio;
using System.Linq;
using Excepciones;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.BaseDatos
{

    public class RepositorioPaises : IRepositorioPaises
    {
        public LibreriaContext Contexto { get; set; }

        public RepositorioPaises(LibreriaContext context)
        {
            Contexto = context;
        }
        public void Add(Pais nuevo)
        {
            try
            {
                nuevo.Validar();
                Contexto.Paises.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch(PaisException ex)
            {
                throw new PaisException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new PaisException(ex.Message);
            }
        }

        private void ValidarPaisEnSeleccion(Pais pais)
        {
            List<Seleccion> selecciones = Contexto.Selecciones.ToList();
            foreach (Seleccion s in selecciones)
            {
                if(s.Pais == pais)
                {
                    throw new PaisException("Pais tiene seleccion");
                }
            }
             
        }

        public IEnumerable<Pais> FindAll()
        {
            return Contexto.Paises.ToList();

        }

        public Pais FindById(int id)
        {
            if (id == 0) throw new PaisException("El id del pais no puede ser 0");
            return Contexto.Paises.Find(id);
        }

        public Pais FindPaisByCodigo(string codigo)
        {

            List<Pais> paises = Contexto.Paises.ToList();
            foreach (Pais p in paises)
            {
                if (p.CodigoISOAlfa3 == codigo)
                {
                    return p;
                }
            }
            throw new PaisException("No se enconuentra pais por codigo");
        }

        public IEnumerable<Pais> GetPaisesByRegion(int region)
        {
            return Contexto.Paises.Where(x => x.Region.Id == region);
        }

        public void Remove(int id)
        {
            try
            {
                Pais aBorrar = Contexto.Paises.Find(id);
                if (aBorrar == null) throw new PaisException("No existe el pais a borrar");
                ValidarPaisEnSeleccion(aBorrar);
                Contexto.Paises.Remove(aBorrar);
                Contexto.SaveChanges();
                
            }
            catch (PaisException ex)
            {
                throw new PaisException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new PaisException(ex.Message);
            }
        }

        public void Update(Pais modificado)
        {
            try
            {
                modificado.Validar();
                Contexto.Update(modificado);
                Contexto.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("No se puede editar el Pais", e);
            }
        }

        public bool ValidarEliminacion()
        {
            throw new NotImplementedException();
        }
    }
}
