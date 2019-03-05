using Shelterly.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shelterly.Controllers.Api
{
    public class AnimalsController : ApiController
    {
        private ApplicationDbContext context;
        public AnimalsController()
        {
            context = new ApplicationDbContext();
        }

        // api/animals
        public IEnumerable<Animal> GetAnimals()
        {
            return context.Animals.ToList();
        }

        // api/animals/1
        public IHttpActionResult GetAnimal(int id)
        {
            var animal = context.Animals
                .SingleOrDefault(a => a.Id == id);

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpPost]
        public IHttpActionResult AddAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            context.Animals.Add(animal);
            context.SaveChanges();

            return Created(new Uri(Request.RequestUri+"/" + animal.Id), animal);
        }
    }
}
