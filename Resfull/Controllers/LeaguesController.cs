using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Resfull.Models;

namespace Resfull.Controllers
{
    public class LeaguesController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/Leagues
        public IQueryable<Leagues> GetLeagues()
        {
            return db.Leagues;
        }

        // GET: api/Leagues/5
        [ResponseType(typeof(Leagues))]
        public IHttpActionResult GetLeagues(int id)
        {
            Leagues leagues = db.Leagues.Find(id);
            if (leagues == null)
            {
                return NotFound();
            }

            return Ok(leagues);
        }

        // PUT: api/Leagues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeagues(int id, Leagues leagues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != leagues.League_ID)
            {
                return BadRequest();
            }

            db.Entry(leagues).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeaguesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Leagues
        [ResponseType(typeof(Leagues))]
        public IHttpActionResult PostLeagues(Leagues leagues)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Leagues.Add(leagues);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LeaguesExists(leagues.League_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = leagues.League_ID }, leagues);
        }

        // DELETE: api/Leagues/5
        [ResponseType(typeof(Leagues))]
        public IHttpActionResult DeleteLeagues(int id)
        {
            Leagues leagues = db.Leagues.Find(id);
            if (leagues == null)
            {
                return NotFound();
            }

            db.Leagues.Remove(leagues);
            db.SaveChanges();

            return Ok(leagues);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeaguesExists(int id)
        {
            return db.Leagues.Count(e => e.League_ID == id) > 0;
        }
    }
}