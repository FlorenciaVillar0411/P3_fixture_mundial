using Excepciones;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosController : ControllerBase
    {
        public IRepositorioPartidos RepoPartidos { get; set; }

        public PartidosController(IRepositorioPartidos repoPartidos)
        {
            RepoPartidos = repoPartidos;
        }
        // GET: api/<PartidosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RepoPartidos.FindAll());
        }

        // GET api/<PartidosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Partido buscado = RepoPartidos.FindById(id);
                if (buscado == null) return NotFound();
                return Ok(buscado);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        // GET api/<PartidosController>/5/tarjetas
        [HttpGet("{id}/tarjetas")]
        public IActionResult GetTarjetas(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Partido buscado = RepoPartidos.FindById(id);
                if (buscado == null) return NotFound();
                return Ok(buscado.GetTarjetas());
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<PartidosController>
        [HttpPost]
        public IActionResult Post([FromBody] Partido value)
        {
            try
            {
                if (value == null) return BadRequest();
                RepoPartidos.Add(value);
                return Created("api/partidos" + value.Id, value);
            }
            catch (PartidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<PartidosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Partido value)
        {
            try
            {
                if (value == null || value == null) return BadRequest();
                value.Id = id;
                RepoPartidos.Update(value);
                return Created("api/partidos" + value.Id, value);
            }
            catch (PartidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<PartidosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                RepoPartidos.Remove(id);
                return NoContent();
            }
            catch (PartidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
