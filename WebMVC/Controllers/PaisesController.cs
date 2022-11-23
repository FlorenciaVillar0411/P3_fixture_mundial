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
using Excepciones;

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
        [HttpGet]
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
                vm.Regiones = CUListadoRegiones.ObtenerListado();
                vm.Nuevo.RegionId = vm.IdRegion;
                vm.Regiones = CUListadoRegiones.ObtenerListado();

                FileInfo fi = new FileInfo(vm.Imagen.FileName);
                string extension = fi.Extension;

                //creamos un nombre unico para la imagen
                string nombreImagen = vm.Nuevo.CodigoISOAlfa3 + "_" + extension;
                //guardamos ese nombre en el Pais
                vm.Nuevo.Imagen = nombreImagen;

                //obtenemos la ruta a la raiz de la aplicacion (wwwroot)
                string rutaRaiz = WHE.WebRootPath;

                //armamos la ruta a la carpeta "Banderas"
                string rutaCarpeta = Path.Combine(rutaRaiz, "Banderas");

                //armamos la ruta del archivo
                string rutaArchivo = Path.Combine(rutaCarpeta, nombreImagen);


                //si llegamos aca es porque el esta se dio, guardamos la img

                //creamos un string para crear el archivo
                FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
                //copiamos a FileSystem (fs) la imagen a traves del stream 
                vm.Imagen.CopyTo(fs);

                CUAltaPais.Alta(vm.Nuevo);
                return RedirectToAction(nameof(Index));
            }
            catch(PaisException ex)
            {

                ViewBag.Error = ex.Message;
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);

            }
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int id)
        {
            PaisViewModel vm1 = new PaisViewModel();
            Pais p = new Pais();
            vm1.Nuevo = p;
            vm1.Nuevo.Id = id;
            vm1.Regiones = CUListadoRegiones.ObtenerListado();
            return View(vm1);
        }

        // POST: Paises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PaisViewModel vm)
        {
            try
            {
                vm.Regiones = CUListadoRegiones.ObtenerListado();
                vm.Nuevo.RegionId = vm.IdRegion;
                vm.Regiones = CUListadoRegiones.ObtenerListado();

                FileInfo fi = new FileInfo(vm.Imagen.FileName);
                string extension = fi.Extension;

                //creamos un nombre unico para la imagen
                string nombreImagen = vm.Nuevo.CodigoISOAlfa3 + "_" + extension;
                //guardamos ese nombre en el Pais
                vm.Nuevo.Imagen = nombreImagen;

                //obtenemos la ruta a la raiz de la aplicacion (wwwroot)
                string rutaRaiz = WHE.WebRootPath;

                //armamos la ruta a la carpeta "Banderas"
                string rutaCarpeta = Path.Combine(rutaRaiz, "Banderas");

                //armamos la ruta del archivo
                string rutaArchivo = Path.Combine(rutaCarpeta, nombreImagen);


                //si llegamos aca es porque el esta se dio, guardamos la img

                //creamos un string para crear el archivo
                FileStream fs = new FileStream(rutaArchivo, FileMode.Create);
                //copiamos a FileSystem (fs) la imagen a traves del stream 
                vm.Imagen.CopyTo(fs);
                CUModificarPais.Modificar(vm.Nuevo);
                return RedirectToAction(nameof(Index));
            }
            catch (PaisException ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(vm);
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
            catch (PaisException ex)
            {
                ViewBag.deleteError = ex.Message;
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
                if(paisBuscado == null) {
                    ViewBag.msg = "No hay paises con ese id";
                }
                return View(paisBuscado);
            }
            catch (PaisException ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }

        // GET: Paises/BuscarPorCodigo
        public ActionResult BuscarPorCodigo(string CodigoISOAlfa3)
        {
            return View();
        }

        // POST: Paises/Buscar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BuscarPorCodigo(string CodigoISOAlfa3, IFormCollection collection)
        {
            try
            {
                Pais paisBuscado = CUBuscarPais.Buscar(CodigoISOAlfa3);
                if (paisBuscado == null)
                {
                    ViewBag.msg = "No hay paises con ese codigo";
                }
                return View(paisBuscado);
            }
            catch (PaisException ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }

        // GET: Paises/BuscarPorCodigo
        public ActionResult PaisPorRegion(int IdRegion)
        {
            PaisRegionModel vm = new PaisRegionModel();
            vm.Regiones = CUListadoRegiones.ObtenerListado();
            vm.Paises = CUListadoPaises.ObtenerListado();

            return View(vm);
        }

        // POST: Paises/Buscar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaisPorRegion(int IdRegion, PaisRegionModel vm)
        {
            try
            {
                IEnumerable<Pais> paisesBuscado = CUBuscarPais.BuscarPorRegion(IdRegion);
                if (paisesBuscado == null)
                {
                    ViewBag.msg = "No hay paises en esa region";
                }
                vm.Paises = paisesBuscado;
                vm.Regiones = CUListadoRegiones.ObtenerListado();
                return View(vm);
            }
            catch (PaisException ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.msg = ex.Message;
                return View();
            }
        }
    }
}