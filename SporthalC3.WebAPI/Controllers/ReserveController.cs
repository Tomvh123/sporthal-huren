﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SporthalC3.Domain;
using SporthalC3.Models;

namespace SporthalC3.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReserveController : Controller
    {
        private ISportHalRepository repository;

        public ReserveController(ISportHalRepository repo)
        {
            repository = repo;
        }

        
        [HttpGet("SporthalId")]
        public IActionResult GetBySportHallId(int id, String dateTime)
        {
            DateTime dt = Convert.ToDateTime(dateTime);
            return Ok(repository.GetReservesById(id, dt));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(repository.Reserve);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Reserve reserve)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            repository.SaveReserve(reserve);
            return CreatedAtAction(nameof(Get),
                new { id = reserve.ReserveID }, reserve);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            repository.DeleteReserve(id);
            return Ok(repository.Reserve);
        }
    }
}