using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
namespace LogicaAccesoDatos.BaseDatos
{    
        public class LibreriaContext : DbContext
        {
            public DbSet<Pais> Paises { get; set; }
            public DbSet<Region> Regiones { get; set; }
            public DbSet<Fase> Fases { get; set; }
            public DbSet<Grupo> Grupos { get; set; }
            public DbSet<Partido> Partidos { get; set; }
            public DbSet<Seleccion> Selecciones { get; set; }
            public DbSet<Tarjeta> Tarjetas { get; set; }
            public DbSet<PartidoFixture> PartidosFixture { get; set; }
            public DbSet<Resultado> Resultados { get; set; }



        public LibreriaContext(DbContextOptions<LibreriaContext> opciones) : base(opciones)
            {
            }
        
        }


    }