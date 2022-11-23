using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LogicaNegocio;
using LogicaNegocio.InterfacesRepositorios;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public IRepositorioUsuario Repo { get; set; }

        public UsuarioController(IRepositorioUsuario repo)
        {
            Repo = repo;
        }




        // GET api/<UsuarioController>/5
        [HttpGet]
        [HttpPost("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();
                Usuario buscado = Repo.Find(usuario);
                if (buscado == null) return NotFound();
                if(buscado.Password != usuario.Password)
                {
                    return NotFound(new Exception("Incorrect password"));
                }
                return Ok(buscado.Rol.Nombre);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<UsuarioController>
        [HttpPost]
        [HttpPost("registro")]
        public IActionResult Registro([FromBody] Usuario usuario)
        {
            try
            {
                if (usuario == null) return BadRequest();

                Rol rol = new Rol();
                rol.Nombre = usuario.Rol.Nombre;
                usuario.Rol.Nombre = "Invitado";
                
                Repo.Add(usuario);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
