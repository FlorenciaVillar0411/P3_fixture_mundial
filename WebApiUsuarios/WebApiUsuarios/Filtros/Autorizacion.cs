using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiUsuarios.Filtros
{
    public class Autorizacion : Attribute, IAuthorizationFilter
    {

        public string[] Roles { get; set; }

        //el params toma todo lo que mandemos entre comas y lo coloca en un array
        //en el create de autor 

        //hago un constructor al cual le voy a pasar roles
        public Autorizacion(params string[] roles)
        {
            Roles = roles;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //me traigo el rol del usuario
            string rolUsuario = context.HttpContext.Session.GetString("rol");

            //si no hay rol o no esta en la lista de roles
            if (rolUsuario == null || !Roles.Any(rol => rol == rolUsuario)) // !Roles.Contains(rolUsuario)
            {
                context.Result = new RedirectToActionResult("login", "usuarios", null);
            }
        }
    }
    //NO OLVIDAR DAR AUTHORIZATION CUANDP CREO EL USUARIO
}
