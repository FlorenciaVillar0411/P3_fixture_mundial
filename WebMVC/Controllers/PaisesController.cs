using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogicaNegocio;
using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;

namespace WebMVC.Controllers
{
    public class PaisesController : Controller
    {
        public IAltaPais CUAltaPais { get; set; }

        public IListadoPaises CUListadoPaises { get; set; }

        public PaisesController(IListadoPaises cuPaises, IAltaPais cuAlta)
        {
            CUAltaPais = cuAlta;
            CUListadoPaises = cuPaises;
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
            return View();
        }

        // POST: Paises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pais nuevo)
        {
            try
            {
                // TODO: Add insert logic here
                CUAltaPais.Alta(nuevo);
                return RedirectToAction(nameof(Index));
            }
            catch {

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