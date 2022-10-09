using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.Dominio;

namespace LogicaAccesoDatos.BaseDatos
{
    public class LibreriaContext: DbContext
    {
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Region> Regiones { get; set; }

        public LibreriaContext(DbContextOptions<LibreriaContext> opciones): base(opciones)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }

    
}
