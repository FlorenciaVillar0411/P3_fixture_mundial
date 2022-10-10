using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
namespace LogicaAccesoDatos.BaseDatos
{
    
        public class LibreriaContext : DbContext
        {
            public DbSet<Pais> Paises { get; set; }
            public DbSet<Region> Regiones { get; set; } 

            public LibreriaContext(DbContextOptions<LibreriaContext> opciones) : base(opciones)
            {

            }

        }


    }
