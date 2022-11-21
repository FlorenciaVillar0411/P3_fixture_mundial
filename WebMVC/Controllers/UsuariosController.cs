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
            HttpContext.Session.SetString("rol", vm.Rol);

            ViewBag.Mensaje = "Bienvenido " + vm.Usuario;
            return View();
        }
    }
}
