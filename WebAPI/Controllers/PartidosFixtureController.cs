using Excepciones;
using LogicaNegocio.Dominio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartidosFixtureController : ControllerBase
    {

        public IRepositorioPartidoFixture RepoPartidos { get; set; }

        public PartidosFixtureController(IRepositorioPartidoFixture repoPartidos)
        {
            RepoPartidos = repoPartidos;
        }
        // GET: api/<PartidosFixtureController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RepoPartidos.FindAll());
        }

        // GET api/<PartidosFixtureController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                PartidoFixture buscado = RepoPartidos.FindById(id);
                if (buscado == null) return NotFound();
                return Ok(buscado);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<PartidosFixtureController>
        [HttpPost]
        public IActionResult Post([FromBody] PartidoFixture value)
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

        // PUT api/<PartidosFixtureController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PartidoFixture value)
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

        // DELETE api/<PartidosFixtureController>/5
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

        // DELETE api/<PartidosFixtureController>/grupo
        [HttpGet("grupo/{grupo}")]
        public IActionResult PorGrupo(string grupo)
        {
            try
            {
                IEnumerable<PartidoFixture> partidos = RepoPartidos.PorGrupo(grupo);

                return Ok(RepoPartidos.PorGrupo(grupo));
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

        // GET api/<SeleccionesController>/5/goles
        [HttpGet("{id}/tarjetas")]
        public IActionResult VerTarjetas(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                IEnumerable<Tarjeta> tarjetas = RepoPartidos.VerTarjetas(id);
                return Ok(tarjetas);
            }
            catch (SeleccionException ex)
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
