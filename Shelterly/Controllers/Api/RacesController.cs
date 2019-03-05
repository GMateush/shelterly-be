using Shelterly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Shelterly.Controllers.Api
{
    public class RacesController : ApiController
    {
        private ApplicationDbContext context;
        public RacesController()
        {
            context = new ApplicationDbContext();
        }

        // api/races
        public IEnumerable<Race> GetRaces()
        {
            return context.Races.ToList();
        }


        // api/races/1
        public IHttpActionResult GetRace(int id)
        {
            var race = context.Races.SingleOrDefault(r => r.Id == id);

            if (race == null)
                return NotFound();

            return Ok(race);
        }


        // api/races
        [HttpPost]
        public IHttpActionResult AddRace(Race race)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            context.Races.Add(race);
            context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + race.Id), race);
        }

        // api/races/1
        [HttpPut]
        public void UpdateRace(int id, Race race)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var raceInDb = context.Races.SingleOrDefault(r => r.Id == id);

            if (raceInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            raceInDb.RaceName = race.RaceName;

            context.SaveChanges();
        }


        // api/races/1
        [HttpDelete]
        public void RemoveRace(int id)
        {
            var raceInDb = context.Races.SingleOrDefault(r => r.Id == id);

            if (raceInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            context.Races.Remove(raceInDb);
            context.SaveChanges();
        }
    }
}
