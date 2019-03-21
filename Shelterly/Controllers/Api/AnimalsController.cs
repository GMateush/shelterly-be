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

        [Route("api/animals/shelter{id}")]
        public IEnumerable<Animal> GetAnimalsFromShelter(int id)
        {
            return context.Animals.Where(a => a.ShelterId == id).ToList();
        }

        // api/animals
        [HttpPost]
        public IHttpActionResult AddAnimal(Animal animal)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            context.Animals.Add(animal);
            context.SaveChanges();

            return Created(new Uri(Request.RequestUri+"/" + animal.Id), animal);
        }

        // api/animals/1
        [HttpPut]
        public void UpdateAnimal(int id, Animal animal)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var animalInDb = context.Animals.SingleOrDefault(a => a.Id == id);

            if (animalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            animalInDb.Name = animal.Name;
            animalInDb.RaceId = animal.RaceId;
            animalInDb.ShelterId = animal.ShelterId;
            animalInDb.DateOfBirth = animal.DateOfBirth;
            animalInDb.Description = animal.Description;

            context.SaveChanges();
        }

        // api/animals/1
        [HttpDelete]
        public void RemoveAnimal(int id)
        {
            var animalInDb = context.Animals.SingleOrDefault(a => a.Id == id);

            if (animalInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Animals.Remove(animalInDb);
            context.SaveChanges();
        }

    }
}
