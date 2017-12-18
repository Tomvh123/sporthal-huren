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
    public class SportsAdminsController : Controller
    {

        private ISportHalRepository repository;

        public SportsAdminsController(ISportHalRepository repo)
        {
            repository = repo;
        }
        //GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.SportsBuildingAdministratorOnly);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sportsBuildingAdministrator = repository.SportsBuildingAdministratorOnly.SingleOrDefault(p => p.SportsBuildingAdministratorID == id);

            if (sportsBuildingAdministrator == null)
            {
                return NotFound();
            }
            return Ok(sportsBuildingAdministrator);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]SportsBuildingAdministrator sportsBuildingAdministrator)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.SaveSportsBuildingAdministrator(sportsBuildingAdministrator);
            return CreatedAtAction(nameof(Get),
                new { id = sportsBuildingAdministrator.SportsBuildingAdministratorID }, sportsBuildingAdministrator);

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
