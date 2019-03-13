using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroCatalogue.Models;
using SuperHeroCatalogue.Services;

namespace SuperHeroCatalogue.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class SuperHeroesController : ControllerBase
    {
        private ISuperHeroService _superHeroService;

        public SuperHeroesController(ISuperHeroService service)
        {
            _superHeroService = service;
        }

        // GET: api/SuperHeroes
        [HttpGet]
        public IEnumerable<SuperHero> GetSuperHeroes()
        {
            return _superHeroService.GetAll();
        }

        // GET: api/SuperHeroes/5
        [HttpGet("{id}")]
        public IActionResult GetSuperHero([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var superHero = _superHeroService.Get(id);

            if (superHero == null)
            {
                return NotFound();
            }

            return Ok(superHero);
        }

        // PUT: api/SuperHeroes/5
        [HttpPut("{id}")]
        public IActionResult PutSuperHero([FromRoute] int id, [FromBody] SuperHero superHero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != superHero.Id)
            {
                return BadRequest();
            }

            try
            {
                _superHeroService.Update(id, superHero);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        // POST: api/SuperHeroes
        [HttpPost]
        public IActionResult PostSuperHero([FromBody] SuperHero superHero)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _superHeroService.Insert(superHero);

            return CreatedAtAction("GetSuperHero", new { id = superHero.Id }, superHero);
        }

        // DELETE: api/SuperHeroes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSuperHero([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var superHero = _superHeroService.Get(id);
            if (superHero == null)
            {
                return NotFound();
            }

            _superHeroService.Delete(id);

            return Ok(superHero);
        }

        private bool SuperHeroExists(int id)
        {
            return _superHeroService.GetAll().Any(e => e.Id == id);
        }
    }
}