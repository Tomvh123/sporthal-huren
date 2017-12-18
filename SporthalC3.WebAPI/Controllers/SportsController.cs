using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SporthalC3.Domain;
using SporthalC3.Models;

namespace SporthalC3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class SportsController : Controller
    {

        private ISportHalRepository repository;

        public SportsController(ISportHalRepository repo)
        {
            repository = repo;
        }
        //GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.Sport);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Sport = repository.Sport.SingleOrDefault(p => p.SportID == id);

            if (Sport == null)
            {
                return NotFound();
            }
            return Ok(Sport);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Sport sport)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.SaveSport(sport);
            return CreatedAtAction(nameof(Get),
                new { id = sport.SportID }, sport);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}