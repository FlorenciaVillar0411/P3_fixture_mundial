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
using Excepciones;

namespace WebMVC.Controllers
{
    public class PaisesController : Controller
    {
        public IAltaPais CUAltaPais { get; set; }

        public IListadoPaises CUListadoPaises { get; set; }
        public IListadoRegiones CUListadoRegiones { get; set; }

        public PaisesController(IListadoPaises cuPaises, IAltaPais cuAlta, IListadoRegiones cuRegiones)
        {
            CUAltaPais = cuAlta;
            CUListadoPaises = cuPaises;
            CUListadoRegiones = cuRegiones;
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
            return View();
        }

        // POST: Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PaisViewModel vm)
        {
            try
            {
                // TODO: Add insert logic here
                vm.Nuevo.RegionId = vm.IdRegion;
                CUAltaPais.Alta(vm.Nuevo);
                return RedirectToAction(nameof(Index));
            }
            catch (PaisException e){

                ViewBag.Error = e.Message;
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
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}