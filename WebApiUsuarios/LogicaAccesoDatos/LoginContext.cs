using System;
using System.Collections.Generic;
using System.Text;
using LogicaNegocio;
using Microsoft.EntityFrameworkCore;


namespace LogicaAccesoDatos
{
    public class LoginContext: DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }


        public LoginContext(DbContextOptions<LoginContext> opciones) : base(opciones)
        {
        }
    }
}
