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
    public class SportsBuildingsController : Controller
    {

        private ISportHalRepository repository;

        public SportsBuildingsController(ISportHalRepository repo)
        {
            repository = repo;
        }
        //GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.SportsBuildingOnly);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sportsbuilding = repository.SportsBuildingOnly.SingleOrDefault(p => p.SportsBuildingID == id);

            if (sportsbuilding == null)
            {
                return NotFound();
            }
            return Ok(sportsbuilding);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SportsBuilding sportsBuilding)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.SaveSportsBuilding(sportsBuilding);
            return CreatedAtAction(nameof(Get),
                new { id = sportsBuilding.SportsBuildingID }, sportsBuilding);

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