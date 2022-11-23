using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogicaAccesoDatos
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        public LoginContext Contexto { get; set; }

        public RepositorioUsuario(LoginContext contexto)
        {
            Contexto = contexto;
        }

        public void Add(Usuario nuevo)
        {
            try
            {
                nuevo.Validar();
                nuevo.Rol.Validar();
                Contexto.Roles.Add(nuevo.Rol);
                Contexto.Usuarios.Add(nuevo);
                Contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario Find(Usuario usuario)
        {
            try
            {
                Usuario buscado = Contexto.Usuarios.Include(u => u.Rol).Where(u => u.Email == usuario.Email).FirstOrDefault();
                
                return buscado;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Rol> Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void Registro()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Usuario obj)
        {
            throw new NotImplementedException();
        }
    }
}
