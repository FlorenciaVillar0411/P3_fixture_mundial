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
    public class ResultadoController : ControllerBase
    {
        public IRepositorioResultado RepoResultado { get; set; }

        public ResultadoController(IRepositorioResultado repo)
        {
            RepoResultado = repo;
        }
        // GET: api/<ResultadoController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(RepoResultado.FindAll());
        }

        // GET api/<ResultadoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Resultado buscado = RepoResultado.FindById(id);
                if (buscado == null) return NotFound();
                return Ok(buscado);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // POST api/<ResultadoController>
        [HttpPost]
        public IActionResult Post([FromBody] Resultado value)
        {
            try
            {
                if (value == null) return BadRequest();
                RepoResultado.Add(value);
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

        // PUT api/<ResultadoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Resultado value)
        {
            try
            {
                if (value == null || value == null) return BadRequest();
                value.Id = id;
                RepoResultado.Update(value);
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

        // DELETE api/<ResultadoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                RepoResultado.Remove(id);
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
                IEnumerable<Resultado> partidos = RepoResultado.PorGrupo(grupo);

                return Ok(RepoResultado.PorGrupo(grupo));
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
