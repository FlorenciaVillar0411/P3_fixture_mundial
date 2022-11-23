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
        public IRepositorioSelecciones RepositorioSelecciones { get; set; }

        public PartidosFixtureController(IRepositorioPartidoFixture repoPartidos, IRepositorioSelecciones repositorioSelecciones)
        {
            RepoPartidos = repoPartidos;
            RepositorioSelecciones = repositorioSelecciones;
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


        // GET: api/<PartidosFixtureController>
        [HttpGet("seleccion/{seleccion}")]
        public IActionResult GetBySeleccion(string seleccion)
        {
            try
            {
                if (seleccion == null) return BadRequest();
                IEnumerable<PartidoFixture> partidos = RepoPartidos.FindAll();

                var ret = partidos.Where(p => {
                    Seleccion s1 = RepositorioSelecciones.FindById(p.IdEquipoDos);
                    Seleccion s2 = RepositorioSelecciones.FindById(p.IdEquipoUno);
                    if(s1.Nombre == seleccion || s2.Nombre == seleccion || s1.Pais.Nombre == seleccion || s2.Pais.Nombre == seleccion)
                    {
                        return true;
                    } else
                    {
                        return false;
                    }

                    });
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500);
            }
        }


        // GET: api/<PartidosFixtureController>
        [HttpGet("codigoPais/{codigo}")]
        public IActionResult GetByCodigo(string codigo)
        {
            try
            {
                if (codigo == null) return BadRequest();
                IEnumerable<PartidoFixture> partidos = RepoPartidos.FindAll();

                var ret = partidos.Where(p => {
                    Seleccion s1 = RepositorioSelecciones.FindById(p.IdEquipoDos);
                    Seleccion s2 = RepositorioSelecciones.FindById(p.IdEquipoUno);
                    if (s1.Pais.CodigoISOAlfa3 == codigo || s2.Pais.CodigoISOAlfa3 == codigo)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                });
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        // GET: api/<PartidosFixtureController>
        [HttpGet]
        [Route("desde/{desde}/hasta/{hasta}")]
        public IActionResult GetByFecha(string desde, string hasta)
        {
            if (desde == null || hasta == null) return BadRequest();

            DateTime fdesde = new DateTime();
            bool ok1 = DateTime.TryParse(desde, out fdesde);
            DateTime fhasta = new DateTime();
            bool ok2 = DateTime.TryParse(hasta, out fhasta);
            if (!ok1 || !ok2) return BadRequest("fecha no valida");

            try
            {
                IEnumerable<PartidoFixture> partidos = RepoPartidos.FindAll();

                var ret = partidos.Where(p => p.Fecha < fhasta && p.Fecha > fdesde);
                return Ok(ret);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
