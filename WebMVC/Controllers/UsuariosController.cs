using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMVC.Models;

namespace WebMVC.Controllers
{
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
            //PENDIENTE VALIDAR QUE EL USUARIO EXISTE Y TIENE ESE ROL

            Usuario login = validarDatosLogin(vm);
            string rol;

            if(login != null)
            {
                if(login is Admin)
                {
                    rol = "admin";
                }
                else if (login = Apostador)
                {
                    rol = "apostador";
                }
                else if (login = Invitado)
                {
                    rol = "invitado";
                }
                else
                {
                    rol = "usuario sin identificar";
                }
                HttpContext.Session.SetString("rol", vm.Rol);

                ViewBag.Mensaje = "Bienvenido " + vm.Usuario;
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.msg = "Datos no validos";
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
