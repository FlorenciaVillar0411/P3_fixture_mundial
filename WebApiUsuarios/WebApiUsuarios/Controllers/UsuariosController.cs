using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiUsuarios.Models;

namespace WebApiUsuarios.Controllers
{
    //CON ESTO VAMOS A NECESITAR UNA BASE DE DATOS DIFERENTE

    public class UsuariosController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel vm)
        {
            //EL PROFE PASO UN VIEW MODEL PERO NO SE SI SI NO ES MEJOR PASAR USERNAME Y PASSWORD
            //NO ESTA BIEN DEL TODO, FALTA TERMINAR DE PENSARLA
            //NO SE SI HACER CLASE DE CADA TIPO DE USUARIO O NO
            Usuario login = vm.ValidarDatosLogin(); 
            string rol;
            if (login != null)
            {
                if (login.rol = Admin) 
                {
                    rol = "Admin"
                }
                else if (login is Apostador) 
                {
                    rol = "Apostador";
                }
                else if (login is Visitante)
                {
                    rol = "Visitante";
                }
                else 
                {
                    rol = "Usuario no identificado";
                }
                HttpContext.Session.SetInt32("LogueadoId", login.Id);
                HttpContext.Session.SetString("LogueadoRol", rol);

                ViewBag.msg = "Bienvenido";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Datos no válidos";
                return View();
            }
        }
        public IActionResult Logout() //si se desea cerrar sesion, se hace clear del rol y se redirige a index
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        
    }
}
