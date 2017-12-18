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
            var sport = repository.Sport.SingleOrDefault(p => p.SportID == id);

            if (sport == null)
            {
                return NotFound();
            }
            return Ok(sport);
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

        //PUt api/Sportsbuildings/5
        [HttpPut]
        public IActionResult Put([FromBody]Sport sport)
        {

            repository.SaveSportAPI(sport);
            return Ok(repository.Sport);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Sport sport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            sport.SportID = id;

            repository.SaveSport(sport);
            return CreatedAtAction(nameof(Get),
                new { id = sport.SportID }, sport);
        }

        [HttpDelete]
        public IActionResult Delete()
        {

            repository.DeleteSportAPI();
            if (repository.Sport.Count() != 0)
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
            repository.DeleteSport(id);
            return Ok(repository.Sport);


        }
    }
}