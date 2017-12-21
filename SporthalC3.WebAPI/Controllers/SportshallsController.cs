using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SporthalC3.Domain;
using SporthalC3.Models;
using Microsoft.AspNetCore.Cors;

namespace SporthalC3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("MyPolicy")]
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

        //PUt api/SportsHalls/5
        [HttpPut]
        public IActionResult Put([FromBody]SportsHall sportsHall)
        {

            repository.SaveSportsHallAPI(sportsHall);
            return Ok(repository.SportsHallOnly);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SportsHall sportsHall)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            sportsHall.SportsHallID = id;

            repository.SaveSportsHall(sportsHall);
            return CreatedAtAction(nameof(Get),
                new { id = sportsHall.SportsHallID }, sportsHall);
        }

        [HttpDelete]
        public IActionResult Delete()
        {

            repository.DeleteSportsHallAPI();
            if( repository.SportsHall.Count() != 0)
            {
                return BadRequest();
            }
            else
            {
                return Ok();
            }

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.DeleteSportsHall(id);
            return Ok(repository.SportsHallOnly);


        }
    }
}
