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
using Webservice.Models;

namespace Webservice.Controllers
{
    public class MatchupsController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/Matchups
        public IQueryable<Matchups> GetMatchups()
        {
            return db.Matchups;
        }

        // GET: api/Matchups/5
        [ResponseType(typeof(Matchups))]
        public IHttpActionResult GetMatchups(int id)
        {
            Matchups matchups = db.Matchups.Find(id);
            if (matchups == null)
            {
                return NotFound();
            }

            return Ok(matchups);
        }

        // PUT: api/Matchups/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatchups(int id, Matchups matchups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matchups.Matchup_ID)
            {
                return BadRequest();
            }

            db.Entry(matchups).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatchupsExists(id))
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

        // POST: api/Matchups
        [ResponseType(typeof(Matchups))]
        public IHttpActionResult PostMatchups(Matchups matchups)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Matchups.Add(matchups);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MatchupsExists(matchups.Matchup_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = matchups.Matchup_ID }, matchups);
        }

        // DELETE: api/Matchups/5
        [ResponseType(typeof(Matchups))]
        public IHttpActionResult DeleteMatchups(int id)
        {
            Matchups matchups = db.Matchups.Find(id);
            if (matchups == null)
            {
                return NotFound();
            }

            db.Matchups.Remove(matchups);
            db.SaveChanges();

            return Ok(matchups);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatchupsExists(int id)
        {
            return db.Matchups.Count(e => e.Matchup_ID == id) > 0;
        }
    }
}