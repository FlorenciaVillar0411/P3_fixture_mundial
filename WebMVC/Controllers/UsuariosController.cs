using DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebMVC.Models;

using LogicaAplicacion.InterfacesCasosUso;
using LogicaNegocio.Dominio;
using Newtonsoft.Json;
using WebMVC.Filtros;

namespace WebMVC.Controllers
{
    public class UsuariosController : Controller
    {
        public string UrlLogin { get; set; }

        public UsuariosController(IConfiguration conf)
        {
            UrlLogin = conf.GetValue<string>("UrlLogin");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login( string Email, string Password)
        {
            UsuarioDTO u = new UsuarioDTO(Email, Password);
            try
            {

                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
                //nos pide certificado ssl, emcontramos esta solucion en stack overflow

                HttpClient cli = new HttpClient(clientHandler);
                Task<HttpResponseMessage> t1 = cli.PostAsJsonAsync(UrlLogin + "/login", u);
                t1.Wait();
                HttpResponseMessage res = t1.Result;
                string txt = ObtenerBody(res);
                if (res.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("rol", txt);
                    return RedirectToAction("Index", "SeleccionesApi");

                }
                else
                {
                    ViewBag.Error = "Login no exitoso. Error: " + res.ReasonPhrase + txt;
                    return View(); // no va amostrar nada en vez de null 
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ups! " + e.Message;
                return View();
            }
        }
        public IActionResult Logout() //si se desea cerrar sesion, se hace clear del rol y se redirige a index
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(RegistroViewModel vm, string Email, string Password, string Rol)
        {
            vm.Email = Email;
            vm.Password = Password;
            vm.Rol = new RolDTO();
            vm.Rol.Nombre = Rol;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

                HttpClient cli = new HttpClient(clientHandler);
                Task<HttpResponseMessage> t1 = cli.PostAsJsonAsync(UrlLogin + "/registro", vm);
                HttpResponseMessage res = t1.Result;
                string txt = ObtenerBody(res);
                if (res.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("rol", txt);
                    return RedirectToAction("Index", "SeleccionesApi");
                }
                else
                {
                    ViewBag.Error = "Registro no exitoso. Error: " + res.ReasonPhrase + txt;
                    return View();
                }
            }
            catch (Exception e)
            {
                ViewBag.Error = "Ups! " + e.Message;
                return View();
            }
        }



        private string ObtenerBody(HttpResponseMessage respuesta)
        {
            HttpContent contenido = respuesta.Content;

            Task<string> t2 = contenido.ReadAsStringAsync();
            t2.Wait();
            return t2.Result;
        }

    }
}
