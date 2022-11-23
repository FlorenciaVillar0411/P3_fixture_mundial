﻿using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Filtros;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class PartidosApiController : Controller
    {
        public string UrlApiPartidos { get; set; }

        public PartidosApiController(IConfiguration conf)
        {
            UrlApiPartidos = conf.GetValue<string>("UrlApiPartidos");
        }

        // GET: PartidosApi
        [Autorizacion("Admin")]
        public ActionResult Index()
        {
            try
            {
                HttpClient cli = new HttpClient();
                Task<HttpResponseMessage> t1 = cli.GetAsync(UrlApiPartidos);
                HttpResponseMessage res = t1.Result;
                string txt = ObtenerBody(res);
                if (res.IsSuccessStatusCode)
                {
                    List<PartidoFixture> selecciones = JsonConvert.DeserializeObject<List<PartidoFixture>>(txt);
                    return View(selecciones);

                }
                else
                {
                    ViewBag.Error = "No se obtienen selecciones. Error: " + res.ReasonPhrase + txt;
                    return View(new List<PartidoFixture>());
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ups! " + e.Message;
                return View(new List<PartidoFixture>());
            }
        }



        private string ObtenerBody(HttpResponseMessage respuesta)
        {
            HttpContent contenido = respuesta.Content;

            Task<string> t2 = contenido.ReadAsStringAsync();
            t2.Wait();
            return t2.Result;
        }

        // GET: PartidosApi/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PartidosApi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartidosApi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PartidosApi/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PartidosApi/Edit/5
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

        // GET: PartidosApi/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PartidosApi/Delete/5
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

        // GET: /BuscarPorGrupo
        [Autorizacion("Admin")]
        public ActionResult PorGrupo(string grupo)
        {
            BusquedaPartidoViewModel vm = new BusquedaPartidoViewModel();
            vm.Partidos = new List<PartidoFixture>();

            return View(vm);
        }

        // POST: PartidosApiController//BuscarPorGrupo
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autorizacion("Admin")]
        public ActionResult PorGrupo(BusquedaPartidoViewModel vm)
        {
            vm.Partidos = new List<PartidoFixture>();

            try
            {
                HttpClient cli = new HttpClient();
                Task<HttpResponseMessage> t1 = cli.GetAsync(UrlApiPartidos + "/grupo/" + vm.NombreGrupo);
                HttpResponseMessage res = t1.Result;
                string txt = ObtenerBody(res);
                if (res.IsSuccessStatusCode)
                {
                    List<PartidoFixture> parts = JsonConvert.DeserializeObject<List<PartidoFixture>>(txt);
                    vm.Partidos = parts;
                    return View(vm);

                }
                else
                {
                    ViewBag.Error = "No se obtienen partidos. Error: " + res.ReasonPhrase + txt;
                    return View(vm);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ups! " + e.Message;
                return View(vm);
            }
        }


        // GET: /PartidosApiController/PorSeleccion
        [Autorizacion("Admin")]
        public ActionResult PorSeleccion()
        {
            BusquedaPartidoViewModel vm = new BusquedaPartidoViewModel();
            vm.Partidos = new List<PartidoFixture>();

            return View(vm);
        }

        // POST:/PartidosApiController/PorSeleccion
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autorizacion("Admin")]
        public ActionResult PorSeleccion(BusquedaPartidoViewModel vm)
        {
            vm.Partidos = new List<PartidoFixture>();

            try
            {
                HttpClient cli = new HttpClient();
                Task<HttpResponseMessage> t1 = cli.GetAsync(UrlApiPartidos + "/seleccion/" + vm.NombreSeleccion);
                HttpResponseMessage res = t1.Result;
                string txt = ObtenerBody(res);
                if (res.IsSuccessStatusCode)
                {
                    List<PartidoFixture> parts = JsonConvert.DeserializeObject<List<PartidoFixture>>(txt);
                    vm.Partidos = parts;
                    return View(vm);

                }
                else
                {
                    ViewBag.Error = "No se obtienen partidos. Error: " + res.ReasonPhrase + txt;
                    return View(vm);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ups! " + e.Message;
                return View(vm);
            }
        }

        // GET: PartidosApiController/EntreFechas
        [Autorizacion("Admin")]
        public ActionResult EntreFechas()
        {
            BusquedaPartidoViewModel vm = new BusquedaPartidoViewModel();
            vm.Partidos = new List<PartidoFixture>();

            return View(vm);
        }

        // POST: /PartidosApiController/EntreFechas
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autorizacion("Admin")]
        public ActionResult EntreFechas(BusquedaPartidoViewModel vm)
        {
            vm.Partidos = new List<PartidoFixture>();

            try
            {
                string desde = vm.Desde.ToString("dd-MM-yyyy");
                string hasta = vm.Hasta.ToString("dd-MM-yyyy");
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.GetAsync(UrlApiPartidos + "/desde/" + desde + "/hasta/" + hasta);
                HttpResponseMessage res = tarea1.Result;
                string txt = ObtenerBody(res);
                if (res.IsSuccessStatusCode)
                {
                    List<PartidoFixture> parts = JsonConvert.DeserializeObject<List<PartidoFixture>>(txt);
                    vm.Partidos = parts;
                    return View(vm);

                }
                else
                {
                    ViewBag.Error = "No se obtienen partidos. Error: " + res.ReasonPhrase + txt;
                   // vm.PartidoFixture = CUListadoPartidoFixture.ObtenerListado();
                    return View(vm);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ups! " + e.Message;
                return View(vm);
            }
        }

        // GET: /PartidosApiController/PorCodigoPais
        [Autorizacion("Admin")]
        public ActionResult PorCodigoPais()
        {
            BusquedaPartidoViewModel vm = new BusquedaPartidoViewModel();
            vm.Partidos = new List<PartidoFixture>();
            return View(vm);
        }

        // POST: //PartidosApiController/PorCodigoPais
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Autorizacion("Admin")]
        public ActionResult PorCodigoPais(BusquedaPartidoViewModel vm)
        {
            vm.Partidos = new List<PartidoFixture>();

            try
            {
                HttpClient cli = new HttpClient();
                Task<HttpResponseMessage> t1 = cli.GetAsync(UrlApiPartidos + "/codigoPais/" + vm.CodigoPais);
                HttpResponseMessage res = t1.Result;
                string txt = ObtenerBody(res);
                if (res.IsSuccessStatusCode)
                {
                    List<PartidoFixture> parts = JsonConvert.DeserializeObject<List<PartidoFixture>>(txt);
                    vm.Partidos = parts;
                    return View(vm);

                }
                else
                {
                    ViewBag.Error = "No se obtienen partidos. Error: " + res.ReasonPhrase + txt;
                    return View(vm);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ups! " + e.Message;
                return View(vm);
            }
        }
    }
}
