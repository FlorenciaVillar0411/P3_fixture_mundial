using System;
using System.Collections.Generic;
using System.Text;



namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario: IRepositorio<Usuario>
    {

        public List<Rol> Login();
        public void Registro();
        public void Logout();
        Usuario Find(Usuario usuario);
    }
}
