using Shelterly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shelterly.Controllers.Api
{
    public class SheltersController : ApiController
    {
        private ApplicationDbContext context;
        public SheltersController()
        {
            context = new ApplicationDbContext();
        }

        // api/shelters
        public IEnumerable<Shelter> GetShelters()
        {
            return context.Shelters.ToList();
        }


        // api/shelters/1
        public IHttpActionResult GetShelter(int id)
        {
            var shelter = context.Shelters.SingleOrDefault(s => s.Id == id);

            if (shelter == null)
                return NotFound();

            return Ok(shelter);
        }


        // api/shelters
        [HttpPost]
        public IHttpActionResult AddShelter(Shelter shelter)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            context.Shelters.Add(shelter);
            context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + shelter.Id), shelter);
        }

        // api/shelters/1
        [HttpPut]
        public void UpdateShelter(int id, Shelter shelter)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var shelterInDb = context.Shelters.SingleOrDefault(s => s.Id == id);

            if (shelterInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            shelterInDb.ShelterName = shelter.ShelterName;
            shelterInDb.Address = shelter.Address;
            shelterInDb.Capacity = shelter.Capacity;

            context.SaveChanges();
        }


        // api/shelters/1
        [HttpDelete]
        public void RemoveShelter(int id)
        {
            var shelterInDb = context.Shelters.SingleOrDefault(s => s.Id == id);

            if (shelterInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Shelters.Remove(shelterInDb);
            context.SaveChanges();
        }


    }
}
