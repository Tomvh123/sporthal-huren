using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SporthalC3.Domain;
using SporthalC3.Models;
using Halcyon.Web.HAL;
using Halcyon.HAL;

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

            return this.Ok(repository.SportsBuildingOnly);


            //return Ok(repository.SportsBuildingOnly);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sportsbuilding = repository.SportsBuilding.SingleOrDefault(p => p.SportsBuildingID == id);
            //sportsbuilding.SportsHallList = null;
            List<SportsHall> sportshall = repository.SportsHallOnly().Where(p => p.SportsBuilding == sportsbuilding).ToList();
            

            if (sportsbuilding == null)
            {
                return NotFound();
            }


            var buildingModel = new
            {
                id,
                sportsbuilding.Name,
                sportsbuilding.Street,
                sportsbuilding.HouseNumber,
                sportsbuilding.PostalCode,               
            };



            var response = new HALResponse(buildingModel)
                 .AddLinks(new Link[] {
                     new Link("self", "/api/SportsBuildings/{id}"),
                     
               }).AddEmbeddedCollection("sportshallsLinks", sportshall, new Link[]{

                   new Link("self", "/api/SportsHalls/{SportsHallID}" )
               });


            return this.Ok(response);
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

        //PUt api/Sportsbuildings/5
        [HttpPut]
        public IActionResult Put([FromBody]SportsBuilding sportsBuilding)
        {

            repository.SaveSportsBuildingAPI(sportsBuilding);
            return Ok(repository.SportsBuildingOnly);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]SportsBuilding sportsBuilding)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            sportsBuilding.SportsBuildingID = id;

            repository.SaveSportsBuilding(sportsBuilding);
            return CreatedAtAction(nameof(Get),
                new { id = sportsBuilding.SportsBuildingID }, sportsBuilding);
        }

        [HttpDelete]
        public IActionResult Delete()
        {

            repository.DeleteSportsBuildingAPI();
            if (repository.SportsBuildingOnly.Count() != 0)
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
            repository.DeleteSportsBuilding(id);
            return Ok(repository.SportsBuildingOnly);


        }
    }
}