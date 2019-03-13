using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroCatalogue.Models;
using SuperHeroCatalogue.Services;

namespace SuperHeroCatalogue.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SuperPowerController : Controller
    {
        private ISuperPowerService _superPowerService;
        
        public SuperPowerController(ISuperPowerService service)
        {
            this._superPowerService = service;            
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<SuperPower> Get()
        {
            return _superPowerService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetSuperPower([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var superPower = _superPowerService.Get(id);

            if (superPower == null)
            {
                return NotFound();
            }

            return Ok(superPower);
        }

        // PUT: api/SuperPower/5
        [HttpPut("{id}")]
        public IActionResult PutSuperPower([FromRoute] int id, [FromBody] SuperPower superPower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != superPower.Id)
            {
                return BadRequest();
            }

            _superPowerService.Update(id, superPower);
            
            return NoContent();
        }

        // POST: api/SuperPower
        [HttpPost]
        public IActionResult PostSuperPower([FromBody] SuperPower superPower)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _superPowerService.Insert(superPower);
            
            return CreatedAtAction("GetSuperPower", new { id = superPower.Id }, superPower);
        }

        // DELETE: api/SuperPower/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSuperPower([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var superPower = _superPowerService.Get(id);
            if (superPower == null)
            {
                return NotFound();
            }

            _superPowerService.Delete(id);

            return Ok(superPower);
        }

        
    }
}