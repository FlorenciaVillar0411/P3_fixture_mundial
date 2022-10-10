using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeleccionesController : ControllerBase
    {
        public IRepositorioSelecciones RepoSelecciones { get; set; }

        public SeleccionesController(IRepositorioSelecciones repoSelecciones)
        {
            RepoSelecciones = repoSelecciones;
        }


        // GET: api/<SeleccionesController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RepoSelecciones.FindAll());
        }

        // GET api/<SeleccionesController>/5
        [HttpGet("{id}")]
        public Seleccion Get(int id)
        {

            return RepoSelecciones.FindById(id);

            return null;
        }

        // POST api/<SeleccionesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SeleccionesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Seleccion value)
        {
        }

        // DELETE api/<SeleccionesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
