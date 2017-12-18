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
    public class SportsHallsController : Controller
    {

        private ISportHalRepository repository;

        public SportsHallsController(ISportHalRepository repo)
        {
            repository = repo;
        }
       //GET api/values
       [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.SportsHallOnly);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sportshall = repository.SportsHallOnly.SingleOrDefault(p => p.SportsHallID == id);

            if (sportshall == null)
            {
                return NotFound();
            }
            return Ok(sportshall);

            
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SportsHall sportsHall)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.SaveSportsHall(sportsHall);
            return CreatedAtAction(nameof(Get),
                new { id = sportsHall.SportsHallID }, sportsHall);
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
