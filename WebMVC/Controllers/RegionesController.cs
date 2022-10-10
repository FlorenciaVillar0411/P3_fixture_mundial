using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Controllers
{
    public class RegionesController : Controller
    {
        public IAltaRegion CUAltaRegion { get; set; }
        public IListadoRegiones CUListadoRegiones { get; set; }
        // GET: RegionesController
        public RegionesController(IListadoRegiones cuListado, IAltaRegion cuAlta)
        {
            CUAltaRegion = cuAlta;
            CUListadoRegiones = cuListado;
        }
        public ActionResult Index()
        {
            IEnumerable<Region> regiones = CUListadoRegiones.ObtenerListado();
            return View(regiones);
        }

        // GET: RegionesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegionesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegionesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Region region)
        {
            try
            {
                CUAltaRegion.Alta(region);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegionesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegionesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegionesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegionesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
