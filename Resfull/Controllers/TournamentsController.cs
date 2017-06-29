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
    public class TournamentsController : ApiController
    {
        private SELEntities db = new SELEntities();

        // GET: api/Tournaments
        public IQueryable<Tournaments> GetTournaments()
        {
            return db.Tournaments;
        }

        // GET: api/Tournaments/5
        [ResponseType(typeof(Tournaments))]
        public IHttpActionResult GetTournaments(int id)
        {
            Tournaments tournaments = db.Tournaments.Find(id);
            if (tournaments == null)
            {
                return NotFound();
            }

            return Ok(tournaments);
        }

        // PUT: api/Tournaments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTournaments(int id, Tournaments tournaments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tournaments.Tournament_ID)
            {
                return BadRequest();
            }

            db.Entry(tournaments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentsExists(id))
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

        // POST: api/Tournaments
        [ResponseType(typeof(Tournaments))]
        public IHttpActionResult PostTournaments(Tournaments tournaments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tournaments.Add(tournaments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tournaments.Tournament_ID }, tournaments);
        }

        // DELETE: api/Tournaments/5
        [ResponseType(typeof(Tournaments))]
        public IHttpActionResult DeleteTournaments(int id)
        {
            Tournaments tournaments = db.Tournaments.Find(id);
            if (tournaments == null)
            {
                return NotFound();
            }

            db.Tournaments.Remove(tournaments);
            db.SaveChanges();

            return Ok(tournaments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TournamentsExists(int id)
        {
            return db.Tournaments.Count(e => e.Tournament_ID == id) > 0;
        }
    }
}