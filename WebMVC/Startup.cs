using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LogicaNegocio.InterfacesRepositorios;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaAplicacion.CasosUso;
//using LogicaAccesoDatos.Memoria;
using LogicaAccesoDatos.BaseDatos;

namespace WebMVC
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
            services.AddControllersWithViews();
            services.AddScoped<IAltaPais, AltaPais>();
            services.AddScoped<IListadoPaises, ListadoPaises>();
            services.AddScoped<IRepositorioPaises, RepositorioPaises>();
            services.AddScoped<IListadoRegiones, ListadoRegiones>();

            services.AddScoped<IAltaRegion, AltaRegion>();
            services.AddScoped<IRepositorioRegiones, RepositorioRegiones>();
            string strConnection = Configuration.GetConnectionString("MiConexion");
            services.AddDbContext<LibreriaContext>(options => options.UseSqlServer(strConnection));
            services.AddScoped<IBajaPais, BajaPais>();
            services.AddScoped<IModificarPais, ModificarPais>();
            services.AddScoped<IBuscarPais, BuscarPais>();

            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Paises}/{action=Index}/{id?}");
            });
        }
    }
}
