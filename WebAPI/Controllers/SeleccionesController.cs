using Microsoft.AspNetCore.Mvc;
using LogicaNegocio.Dominio;
using DTOs;

using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excepciones;

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

        // GET: api/<SeleccionesController>
        [HttpGet("dto/grupo/{grupo}")]
        public IActionResult Get(string grupo)
        {
            try
            {
                if (grupo == null) return BadRequest();
                IEnumerable<Seleccion> selecciones = RepoSelecciones.FindByGroup(grupo);

                var dtos = selecciones.Select(s =>
                                            new DTOSeleccion(s.Id, s.Nombre,
                                            RepoSelecciones.Puntaje(s),
                                            RepoSelecciones.Goles(s),
                                            RepoSelecciones.GolesEnContra(s)));
                var dtosSorted = dtos.OrderByDescending(s => s.Puntaje);
                return Ok(dtosSorted);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET api/<SeleccionesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Seleccion buscado = RepoSelecciones.FindById(id);
                if (buscado == null) return NotFound();
                return Ok(buscado);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // POST api/<SeleccionesController>
        [HttpPost]
        public IActionResult Post([FromBody] Seleccion nuevo)
        {
            try
            {
                if (nuevo == null) return BadRequest();
                RepoSelecciones.Add(nuevo);
                return Created("api/selecciones" + nuevo.Id, nuevo);
            }
            catch(SeleccionException ex)
            {
                return BadRequest(ex.Message);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<SeleccionesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Seleccion value)
        {
            try
            {
                if (value == null || value == null) return BadRequest();
                value.Id = id;
                RepoSelecciones.Update(value);
                return Created("api/selecciones" + value.Id, value);
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

        // DELETE api/<SeleccionesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                RepoSelecciones.Remove(id);
                return Ok(NoContent());
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

        // GET api/<SeleccionesController>/5/goles
        [HttpGet("{id}/goles")]
        public IActionResult Goles(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Seleccion buscado = RepoSelecciones.FindById(id);
                if (buscado == null) return NotFound();
                int goles = RepoSelecciones.Goles(buscado);
                return Ok(goles);
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
        // GET api/<SeleccionesController>/5/puntaje
        [HttpGet("{id}/puntaje")]
        public IActionResult Puntaje(int id)
        {
            try
            {
                if (id == 0) return BadRequest();
                Seleccion buscado = RepoSelecciones.FindById(id);
                if (buscado == null) return NotFound();
                int goles = RepoSelecciones.Puntaje(buscado);
                return Ok(goles);
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
