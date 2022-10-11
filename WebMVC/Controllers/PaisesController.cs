using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using WebMVC.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WebMVC.Controllers
{
    public class PaisesController : Controller
    {
        public IAltaPais CUAltaPais { get; set; }
        public IListadoPaises CUListadoPaises { get; set; }
        public IListadoRegiones CUListadoRegiones { get; set; }
        public IWebHostEnvironment WHE { get; set; }
        public IBajaPais CUBajaPais { get; set; }
        public IModificarPais CUModificarPais { get; set; }
        public IBuscarPais CUBuscarPais { get; set; }

        public PaisesController(IAltaPais cUAltaPais, IListadoPaises cUListadoPaises, IListadoRegiones cUListadoRegiones, IWebHostEnvironment wHE, IBajaPais cUBajaPais, IModificarPais cUModificarPais, IBuscarPais cUBuscarPais)
        {
            CUAltaPais = cUAltaPais;
            CUListadoPaises = cUListadoPaises;
            CUListadoRegiones = cUListadoRegiones;
            WHE = wHE;
            CUBajaPais = cUBajaPais;
            CUModificarPais = cUModificarPais;
            CUBuscarPais = cUBuscarPais;
        }

        // GET: Paises
        public ActionResult Index()
        {
            IEnumerable<Pais> paises = CUListadoPaises.ObtenerListado();
            return View(paises);
        }

        // GET: Paises/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            PaisViewModel vm = new PaisViewModel();
            vm.Regiones = CUListadoRegiones.ObtenerListado();
            return View(vm);
        }

        // POST: Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisViewModel vm)
        {
            try
            {
                vm.IdRegion = vm.Nuevo.RegionId;
                vm.Nuevo.Imagen = vm.Nuevo.Imagen;

                FileInfo fi = new FileInfo(vm.Imagen.FileName);
                string extension = fi.Extension; 

                //creamos un nombre unico para la imagen
                string nombreImagen = vm.Nuevo.Id + "_" + extension;
                //guardamos ese nombre en el Pais
                vm.Nuevo.Imagen = nombreImagen;

                //obtenemos la ruta a la raiz de la aplicacion (wwwroot)
                string rutaRaiz = WHE.WebRootPath;

                //armamos la ruta a la carpeta "Banderas"
                string rutaCarpeta = Path.Combine(rutaRaiz, "Banderas"); 

                //armamos la ruta del archivo
                string rutaArchivo = Path.Combine(rutaCarpeta, nombreImagen);

                CUAltaPais.Alta(vm.Nuevo);

                //si llegamos aca es porque el esta se dio, guardamos la img

                //creamos un string para crear el archivo
                FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
                //copiamos a FileSystem (fs) la imagen a traves del stream 
                vm.Imagen.CopyTo(fs);

                return RedirectToAction(nameof(Index));
            }
            catch
            {

                ViewBag.Error = "error";
                return View();
            }
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Paises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Pais pais)
        {
            try
            {
                CUModificarPais.Modificar(pais);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Paises/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                CUBajaPais.Baja(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Paises/BuscarPorId
        public ActionResult BuscarPorId(int id)
        {
            return View();
        }

        // POST: Paises/BuscarPorId
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarPorId(int id, IFormCollection collection)
        {
            try
            {
                Pais paisBuscado = CUBuscarPais.Buscar(id);
                if (paisBuscado == null)
                {
                    ViewBag.msg = "No hay paises con ese id";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Paises/BuscarPorCodigo
        public ActionResult BuscarPorCodigo(string codigo)
        {
            return View();
        }

        // POST: Paises/Buscar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarPorCodigo(string codigo, IFormCollection collection)
        {
            try
            {
                Pais paisBuscado = CUBuscarPais.Buscar(codigo);
                if (paisBuscado == null)
                {
                    ViewBag.msg = "No hay paises con ese codigo";
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}