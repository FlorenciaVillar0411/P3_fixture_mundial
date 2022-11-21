using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class SeleccionesApiController : Controller
    {

        public string UrlApiSelecciones { get; set; }
        public IListadoPaises CUListadoPaises { get; set; }
        public IListadoGrupos CUListadoGrupos { get; set; }

        public SeleccionesApiController(IConfiguration conf, IListadoPaises cuListadoPaises)
        {
            UrlApiSelecciones = conf.GetValue<string>("UrlApiSelecciones");
            CUListadoPaises = cuListadoPaises;
        }

        // GET: SeleccionesApiController
        public ActionResult Index() //queremos el listado
        {
            try
            {
                HttpClient cli = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cli.GetAsync(UrlApiSelecciones);
                HttpResponseMessage res = tarea1.Result;
                string txt = ObtenerBody(res);
                if (res.IsSuccessStatusCode)//de la serie 200
                {
                    List<Seleccion> selecciones = JsonConvert.DeserializeObject<List<Seleccion>>(txt);
                    return View(selecciones);

                }
                else
                {
                    ViewBag.Error = "No se obtienen selecciones. Error: " + res.ReasonPhrase + txt; //badrequest, o notfound o internal server error
                    return View(new List<Seleccion>());
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ups! " + e.Message;
                return View(new List<Seleccion>());
            }
        }

        private string ObtenerBody(HttpResponseMessage respuesta)
        {
            HttpContent contenido = respuesta.Content;

            Task<string> tarea2 = contenido.ReadAsStringAsync();
            tarea2.Wait();
            return tarea2.Result;
        }

        // GET: SeleccionesApiController/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                Seleccion seleccion = BuscarPorId(id);
                return View(seleccion);
            }
            catch (Exception ex)
            {
                //Log? 
                ViewBag.Error = "Ups! Ocurrión un error " + ex.Message;
                return View();
            }
        }


        // GET: SeleccionesWebapiController/Create
        public ActionResult Create()
        {
            SeleccionViewModel vm = new SeleccionViewModel();
            vm.Paises = CUListadoPaises.ObtenerListado();
            vm.Grupos = CUListadoGrupos.ObtenerListado();
            return View(vm);
        }

        // POST: SeleccionesWebapiController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SeleccionViewModel vm)
        {
            try
            {
                vm.Paises.Id = vm.IdPaisSeleccionado;
                HttpClient cliente = new HttpClient();

                cliente.DefaultRequestHeaders.Add("token", "123123123");
                Task<HttpResponseMessage> tarea1 = cliente.PostAsJsonAsync(UrlApiSelecciones, vm.seleccion);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                if (respuesta.IsSuccessStatusCode) //status code de la serie 200
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "No se pudo dar de alta la seleccion. Error: " + ObtenerBody(respuesta);
                    vm.Paises = CUListadoPaises.ObtenerListado();
                    vm.Grupos = CUListadoGrupos.ObtenerListado();
                    return View(vm);
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ocurrió un error: " + e.Message;
                //loguear la excepción? inner exception?
                return View(vm);
            }
        }

        // GET: SeleccionesApiController/Edit/5
        public ActionResult Edit(int id)
        {
            Seleccion seleccion = BuscarPorId(id);
            Grupo grupo = BuscarPorIdGrupo(id);
            SeleccionViewModel vm = new SeleccionViewModel();
            vm.seleccion = seleccion;
            vm.IdPaisSeleccionado = seleccion.PaisId;
            vm.IdGrupoSeleccionado = grupo.Id;
            vm.Paises = CUListadoPaises.ObtenerListado();
            vm.Grupos = CUListadoGrupos.ObtenerListado();
            return View(vm);
        }

        // POST: SeleccionesApiController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SeleccionViewModel vm)
        {
            try
            {
                vm.Paises.Id = vm.IdPaisSeleccionado;
                vm.Grupos.Id = vm.IdGrupoSeleccionado;
                HttpClient cliente = new HttpClient();
                Task<HttpResponseMessage> tarea1 = cliente.PutAsJsonAsync(UrlApiSelecciones + "/" + vm.seleccion.Id, vm.seleccion);
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                if (respuesta.IsSuccessStatusCode) //status code de la serie 200
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Error = "No se pudo modificar la seleccion. Error: " + ObtenerBody(respuesta);
                    vm.Paises = CUListadoPaises.ObtenerListado();
                    vm.Grupos = CUListadoGrupos.ObtenerListado();
                    return View(vm);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: SeleccionesApiController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                Seleccion s = BuscarPorId(id);
                if (s == null)
                {
                    ViewBag.Error = "No existe la seleccion a borrar";
                }
                return View(a);
            }
            catch (Exception ex)
            { 
                ViewBag.Error = "Ups! Ocurrión un error " + ex.Message;
                return View();
            }
        }

        // POST: SeleccionesApiController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Seleccion s)
        {
            HttpClient cliente = new HttpClient();

            Task<HttpResponseMessage> tarea1 = cliente.DeleteAsync(UrlApiSelecciones + "/" + id);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            HttpContent contenido = respuesta.Content;

            if (respuesta.IsSuccessStatusCode) //status code de la serie 200
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Error = "No se puede hacer la eliminación. Satus code: " + respuesta.ReasonPhrase +
                                "Descripción: " + ObtenerBody(respuesta);
                return View();
            }
        }
        private Seleccion BuscarPorId(int id)
        {
            Seleccion s = null;

            HttpClient cliente = new HttpClient();

            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(UrlApiSelecciones + "/" + id);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string json = tarea2.Result;

                s = JsonConvert.DeserializeObject<Seleccion>(json);
            }

            return s;
        }
        private Grupo BuscarPorIdGrupo(int id)
        {
            Grupo g = null;

            HttpClient cliente = new HttpClient();

            Task<HttpResponseMessage> tarea1 = cliente.GetAsync(UrlApiSelecciones + "/" + id);
            tarea1.Wait();

            HttpResponseMessage respuesta = tarea1.Result;

            if (respuesta.IsSuccessStatusCode)
            {
                HttpContent contenido = respuesta.Content;

                Task<string> tarea2 = contenido.ReadAsStringAsync();
                tarea2.Wait();

                string json = tarea2.Result;

                s = JsonConvert.DeserializeObject<Grupo>(json);
            }

            return g;
        }
        [HttpGet]
        public ActionResult SeleccionsDTO()
        {
            try
            {
                HttpClient cliente = new HttpClient();

                var tarea1 = cliente.GetAsync(UrlApiSelecciones + "/dto");
                tarea1.Wait();

                HttpResponseMessage respuesta = tarea1.Result;

                string txt = ObtenerBody(respuesta); ;

                if (respuesta.IsSuccessStatusCode)
                {

                    List<ViewModelSeleccionDTO> vmautores = JsonConvert.DeserializeObject<List<ViewModelSeleccionDTO>>(txt);
                    return View(vmautores);
                }
                else
                {
                    ViewBag.Error = "No se pudo obtener la información: " + respuesta.ReasonPhrase + " " + txt;
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error("Ocurrió un error: " + ex.Message);
            }

            return View(new List<ViewModelSeleccionDTO>());
        }

        // GET: Paises/BuscarPorGrupo
        public ActionResult PuntajePorGrupo(string grupo)
            {
                GrupoSeleccionViewModel vm = new GrupoSeleccionViewModel();
                vm.Grupos = CUListadoGrupos.ObtenerListado();
                vm.Selecciones = new List<DTOSeleccion>();
                return View(vm);
            }

            // POST: Paises/Buscar
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult PuntajePorGrupo(string nomGrupo, GrupoSeleccionViewModel vm)
            {
                    vm.Grupos = CUListadoGrupos.ObtenerListado();
                    vm.Selecciones = new List<DTOSeleccion>();
                try
                {
                    HttpClient cli = new HttpClient();
                    Task<HttpResponseMessage> t1 = cli.GetAsync(UrlApiSelecciones + "/dto/grupo/" + vm.NombreGrupo);
                    HttpResponseMessage res = t1.Result;
                    string txt = ObtenerBody(res);
                    if (res.IsSuccessStatusCode)
                    {
                        List<DTOSeleccion> selecciones = JsonConvert.DeserializeObject<List<DTOSeleccion>>(txt);
                        vm.Selecciones = selecciones;
                        return View(vm);

                    }
                    else
                    {
                        ViewBag.Error = "No se obtienen selecciones. Error: " + res.ReasonPhrase + txt;
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
