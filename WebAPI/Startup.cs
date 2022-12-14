using LogicaAccesoDatos.BaseDatos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LogicaNegocio.InterfacesRepositorios;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IRepositorioSelecciones, RepositorioSelecciones>();
            services.AddScoped<IRepositorioPartidos, RepositorioPartidos>();
            services.AddScoped<IRepositorioPartidoFixture, RepositorioPartidoFixture>();
            services.AddScoped<IRepositorioResultado, RepositorioResultado>();
            services.AddScoped<IRepositorioPaises, RepositorioPaises>();

            string strConnection = Configuration.GetConnectionString("MiConexion");
            services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strConnection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
