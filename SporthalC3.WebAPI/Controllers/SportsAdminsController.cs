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
        public IActionResult Post([FromBody]SportsBuildingAdministrator sportsBuildingAdmin)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.SaveSportsBuildingAdministrator(sportsBuildingAdmin);
            return CreatedAtAction(nameof(Get),
                new { id = sportsBuildingAdmin.SportsBuildingAdministratorID }, sportsBuildingAdmin);

        }

        //PUt api/Sportsbuildings/5
        [HttpPut]
        public IActionResult Put([FromBody]SportsBuildingAdministrator sportsBuildingAdmin)
        {

            repository.SaveSportsBuildingAdministratorAPI(sportsBuildingAdmin);
            return Ok(repository.SportsBuildingAdministratorOnly);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SportsBuildingAdministrator sportsBuildingAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            sportsBuildingAdmin.SportsBuildingAdministratorID = id;

            repository.SaveSportsBuildingAdministrator(sportsBuildingAdmin);
            return CreatedAtAction(nameof(Get),
                new { id = sportsBuildingAdmin.SportsBuildingAdministratorID }, sportsBuildingAdmin);
        }

        [HttpDelete]
        public IActionResult Delete()
        {

            repository.DeleteSportsBuildingAdministratorAPI();
            if (repository.SportsBuildingAdministratorOnly.Count() != 0)
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
            repository.DeleteSportsBuildingAdministrator(id);
            return Ok(repository.SportsBuildingAdministratorOnly);


        }
    }
}
