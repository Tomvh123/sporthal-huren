using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SporthalC3.Models;
using SporthalC3.Domain;
using System.Diagnostics;

namespace SporthalC3.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Sportshalls")]
    public class SportshallsController : Controller
    {

        private ISportHalRepository repository;

        public SportshallsController(ISportHalRepository repo)
        {
            repository = repo;
            Console.WriteLine("Werkt");


        }
        private static List<Product> _products = new List<Product>(new[]{
                new Product() {ID = 1, Name = "Green Peppers"},
                new Product() {ID = 2, Name = "Soft Taco"},
                new Product() {ID = 3, Name = "Beef"},
                new Product() {ID = 4, Name = "Chipotle Sauce"},

            });
        [HttpGet]
        public IActionResult Get()
        {
            //System.Diagnostics.Debug.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~bas~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            return Ok(repository.SportsHall.ToList());

        }

        [HttpGet("{id}")] //capture route paramter
        public IActionResult Get(int id)
        {
            var product = repository.SportsHall.SingleOrDefault(p => p.SportsHallID == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //[HttpPost]
        //public IActionResult Post([FromBody] Product product)
        //{

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest();
        //    }

        //    _products.Add(product);
        //    return CreatedAtAction(nameof(Get),
        //        new { id = product.ID }, product);

        //}

    }
}
